using PinBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string windowTitle = "PinBoard";
        private bool isProjectOpen;
        private DataRepository dataRepository;
        private SideBarViewModel sideBarViewModel;


        public string WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; OnPropertyChanged("WindowTitle"); }
        }

        public bool IsProjectOpen
        {
            get { return isProjectOpen; }
            set { isProjectOpen = value; OnPropertyChanged("IsProjectOpen"); }
        }

        public SideBarViewModel SideBarViewModel
        {
            get { return sideBarViewModel; }
            set { sideBarViewModel = value; OnPropertyChanged("SideBarViewModel"); }
        }

        public bool IsProjectDirty
        {
            get
            {
                if (dataRepository != null)
                {
                    return dataRepository.IsDirty;
                }
                else
                {
                    return false;
                }
            }
        }

        public void InitializeMainWindow()
        {
            //add in a open last here, also add in code to launch from file
            SideBarViewModel = new SideBarViewModel();
            SideBarViewModel.InitilizeSideBar(dataRepository);
            //add in initialize canvas view model
        }

        #region Commands

        private RelayCommand onMainMenuNewClick;
        private RelayCommand onMainMenuOpenClick;
        private RelayCommand onMainMenuSaveClick;
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
            dataRepository = new DataRepository();
            InitializeMainWindow();
        }

        private void OnMainMenuOpenClickHandler(object parameter)
        {

        }

        private void OnMainMenuSaveClickHandler(object parameter)
        {

        }

        private void OnMainMenuExitClickHandler(object parameter)
        {

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
