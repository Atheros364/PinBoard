using PinBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.ViewModels
{
    public class MainWindowViewModel
    {







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
    }
}
