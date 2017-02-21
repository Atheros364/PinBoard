using PinBoard.Models;
using PinBoard.Models.DataTypes;
using PinBoard.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.ViewModels
{
    public class TagSelectionWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataRepository dataRepository;
        private Blurb currentBlurb;
        private string tagText = string.Empty;
        private ObservableCollection<Tag> tagsList = new ObservableCollection<Tag>();

        public string TagText
        {
            get { return tagText; }
            set { tagText = value; OnPropertyChanged("TagText"); }
        }

        public ObservableCollection<Tag> TagsList
        {
            get { return tagsList; }
            set { tagsList = value; OnPropertyChanged("TagsList"); }
        }

        public TagSelectionWindowViewModel(DataRepository dataRepository, Blurb blurb)
        {
            this.dataRepository = dataRepository;
            currentBlurb = blurb;
            TagsList = new ObservableCollection<Tag>(currentBlurb.Tags);
        }



        private RelayCommand onCloseClick;
        private RelayCommand onAddClick;

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

        public RelayCommand OnAddClick
        {
            get
            {
                if (onAddClick == null)
                {
                    onAddClick = new RelayCommand(OnAddClickHandler);
                }
                return onAddClick;
            }
        }

        private void OnCloseClickHandler(object obj)
        {
            TagSelectionWindow window = obj as TagSelectionWindow;
            if (window != null)
            {
                window.Close();
            }
        }

        private void OnAddClickHandler(object obj)
        {
            if (TagText != string.Empty && TagsList.Count(t => t.Name == TagText) == 0)
            {
                Tag newTag = dataRepository.TagCollection.FirstOrDefault(t => t.Name == TagText);
                if(newTag == null)
                {
                    newTag = new Tag();
                    newTag.Name = TagText;
                    dataRepository.CreateTag(newTag);
                    newTag = dataRepository.TagCollection.FirstOrDefault(t => t.Name == TagText);
                }
                
                currentBlurb.Tags.Add(newTag);
                TagsList.Add(newTag);
                OnPropertyChanged("TagsList");
                TagText = string.Empty;
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
