using PinBoard.Models;
using PinBoard.Models.DataTypes;
using PinBoard.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.ViewModels
{
    public class BlurbEditWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Blurb currentBlurb;
        private string tagListString = "...";
        private DataRepository dataRepository;

        public string Name
        {
            get { return currentBlurb.Name; }
            set { currentBlurb.Name = value; OnPropertyChanged("Name"); }
        }

        public string Description
        {
            get { return currentBlurb.Description; }
            set { currentBlurb.Description = value; OnPropertyChanged("Description"); }
        }

        public string Body
        {
            get { return currentBlurb.Body; }
            set { currentBlurb.Body = value; OnPropertyChanged("Body"); }
        }

        public string TagListString
        {
            get { return tagListString; }
            set { tagListString = value; OnPropertyChanged("TagListString"); }
        }


        public BlurbEditWindowViewModel(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            currentBlurb = new Blurb();
            Name = "New Blurb";
        }

        public BlurbEditWindowViewModel(DataRepository dataRepository, Blurb blurb)
        {
            this.dataRepository = dataRepository;
            currentBlurb = blurb;
        }





        private RelayCommand onCloseClick;

        public RelayCommand OnCloseClick
        {
            get
            {
                if (onCloseClick == null)
                {
                    onCloseClick = new RelayCommand(OnCloseClickHandler);
                }
                return onCloseClick;
            }
        }

        private void OnCloseClickHandler(object obj)
        {
            if (currentBlurb.Id == 0)
            {
                dataRepository.CreateNewBlurb(currentBlurb);
            }


            BlurbEditWindow window = obj as BlurbEditWindow;
            if (window != null)
            {
                window.Close();
            }
        }

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
