using Microsoft.Win32;
using PinBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PinBoard.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string windowTitle = "PinBoard";
        private bool isProjectOpen;
        private DataRepository dataRepository = new DataRepository();
        private SideBarViewModel sideBarViewModel = new SideBarViewModel();
        private string currentSavePath;

        public string WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; OnPropertyChanged("WindowTitle"); }
        }

        public SideBarViewModel SideBarViewModel
        {
            get { return sideBarViewModel; }
            set { sideBarViewModel = value; OnPropertyChanged("SideBarViewModel"); }
        }

        public void InitializeMainWindow()
        {
            //add in a open last here, also add in code to launch from file
            SideBarViewModel.InitializeSideBar(dataRepository);
            //add in initialize canvas view model
        }

        public void ReloadView()
        {
            SideBarViewModel.UpdateSideBarTagList();
            SideBarViewModel.UpdateBlurbSideBarList();
        }

        #region Commands

        private RelayCommand onMainMenuNewClick;
        private RelayCommand onMainMenuOpenClick;
        private RelayCommand onMainMenuSaveClick;
        private RelayCommand onMainMenuSaveAsClick;
        private RelayCommand onMainMenuExitClick;

        public RelayCommand OnMainMenuNewClick
        {
            get
            {
                if (onMainMenuNewClick == null)
                {
                    onMainMenuNewClick = new RelayCommand(OnMainMenuNewClickHandler);
                }
                return onMainMenuNewClick;
            }
        }

        public RelayCommand OnMainMenuOpenClick
        {
            get
            {
                if (onMainMenuOpenClick == null)
                {
                    onMainMenuOpenClick = new RelayCommand(OnMainMenuOpenClickHandler);
                }
                return onMainMenuOpenClick;
            }
        }

        public RelayCommand OnMainMenuSaveClick
        {
            get
            {
                if (onMainMenuSaveClick == null)
                {
                    onMainMenuSaveClick = new RelayCommand(OnMainMenuSaveClickHandler);
                }
                return onMainMenuSaveClick;
            }
        }

        public RelayCommand OnMainMenuSaveAsClick
        {
            get
            {
                if (onMainMenuSaveAsClick == null)
                {
                    onMainMenuSaveAsClick = new RelayCommand(OnMainMenuSaveAsClickHandler);
                }
                return onMainMenuSaveAsClick;
            }
        }

        public RelayCommand OnMainMenuExitClick
        {
            get
            {
                if (onMainMenuExitClick == null)
                {
                    onMainMenuExitClick = new RelayCommand(OnMainMenuExitClickHandler);
                }
                return onMainMenuExitClick;
            }
        }

        #endregion Commands

        #region Command Handlers

        private void OnMainMenuNewClickHandler(object parameter)
        {
            dataRepository.ResetDataRepository();
            InitializeMainWindow();
        }

        private void OnMainMenuOpenClickHandler(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PinBoard Files (*.pbr)|*.pbr|All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                dataRepository.LoadDataFromFile(openFileDialog.FileName);
                currentSavePath = openFileDialog.FileName;
                ReloadView();
            }
        }

        private void OnMainMenuSaveClickHandler(object parameter)
        {
            if (currentSavePath != null)
            {
                dataRepository.SaveDataToFile(currentSavePath);
            }
            else
            {
                OnMainMenuSaveAsClickHandler(parameter);
            }
        }

        private void OnMainMenuSaveAsClickHandler(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".pbr";
            saveFileDialog.Filter = "PinBoard Files (*.pbr)|*.pbr";
            saveFileDialog.FileName = "*.pbr";
            if (saveFileDialog.ShowDialog() == true)
            {
                dataRepository.SaveDataToFile(saveFileDialog.FileName);
            }
        }

        private void OnMainMenuExitClickHandler(object parameter)
        {
            bool close = true;
            if (dataRepository.IsDirty)
            {
                MessageBoxResult result = MessageBox.Show("You have unsaved changes, would you like to save?", "PinBoard", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        OnMainMenuSaveClickHandler(null);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        close = false;
                        break;
                }
            }

            if (close)
            {
                Application.Current.Shutdown();
            }
        }
        #endregion Command Handlers

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
