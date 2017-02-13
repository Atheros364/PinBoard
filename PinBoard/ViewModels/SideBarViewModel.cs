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
    public class SideBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string searchText = "";
        private ObservableCollection<Tag> tagList = new ObservableCollection<Tag>();
        private Tag selectedTag;
        private ObservableCollection<Blurb> blurbSideBarList = new ObservableCollection<Blurb>();
        private Blurb selectedBlurb;
        private bool isRemoveButtonEnabled;
        private DataRepository dataRepository;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged("SearchText"); }
        }

        public ObservableCollection<Tag> TagList
        {
            get { return tagList; }
            set { tagList = value; OnPropertyChanged("TagList"); }
        }

        public Tag SelectedTag
        {
            get { return selectedTag; }
            set { selectedTag = value; OnPropertyChanged("SelectedTag"); }
        }

        public ObservableCollection<Blurb> BlurbSideBarList
        {
            get { return blurbSideBarList; }
            set { blurbSideBarList = value; OnPropertyChanged("BlurbSideBarList"); }
        }
        public Blurb SelectedBlurb
        {
            get { return selectedBlurb; }
            set
            {
                selectedBlurb = value; OnPropertyChanged("SelectedBlurb");
                IsRemoveButtonEnabled = false;
                if (SelectedBlurb != null)
                {
                    IsRemoveButtonEnabled = true;
                }
            }
        }

        public bool IsRemoveButtonEnabled
        {
            get { return isRemoveButtonEnabled; }
            set { isRemoveButtonEnabled = value; OnPropertyChanged("IsRemoveButtonEnabled"); }
        }




        public void InitializeSideBar(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            UpdateSideBarTagList();
            UpdateBlurbSideBarList();
        }

        public void UpdateSideBarTagList()
        {
            TagList = new ObservableCollection<Tag>(dataRepository.TagCollection);
        }

        public void UpdateBlurbSideBarList()
        {
            SelectedBlurb = null;
            List<Blurb> tempBlurbList = new List<Blurb>();
            foreach (Blurb b in dataRepository.BlurbCollection)
            {
                if (BlurbMatchesTag(b) && BlurbMatchesSearch(b))
                {
                    tempBlurbList.Add(b);
                }
            }
            // add in sort ability
            BlurbSideBarList = new ObservableCollection<Blurb>(tempBlurbList);
        }

        private bool BlurbMatchesSearch(Blurb blurb)
        {
            bool result = false;

            if (blurb.Name.Contains(SearchText))
            {
                result = true;
            }
            else if (blurb.Description.Contains(SearchText))
            {
                result = true;
            }
            else if (blurb.Body.Contains(SearchText))//make this a preference to reduce search times
            {
                result = true;
            }

            return result;
        }

        private bool BlurbMatchesTag(Blurb blurb)
        {
            bool result = false;

            if (SelectedTag == null)
            {
                result = true;
            }
            else if (blurb.Tags.Contains(SelectedTag))//this might not work, might need to write custom comparer
            {
                result = true;
            }

            return result;
        }

        #region Commands

        private RelayCommand onAddClick;
        private RelayCommand onRemoveClick;
        private RelayCommand onEditClick;
        //make right click menu to call these actions as well
        private RelayCommand onSearchClick;//make this call of of enter click in search bar as well


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

        public RelayCommand OnRemoveClick
        {
            get
            {
                if (onRemoveClick == null)
                {
                    onRemoveClick = new RelayCommand(OnRemoveClickHandler);
                }
                return onRemoveClick;
            }
        }

        public RelayCommand OnEditClick
        {
            get
            {
                if (onEditClick == null)
                {
                    onEditClick = new RelayCommand(OnEditClickHandler);
                }
                return onEditClick;
            }
        }

        public RelayCommand OnSearchClick
        {
            get
            {
                if (onSearchClick == null)
                {
                    onSearchClick = new RelayCommand(OnSearchClickHandler);
                }
                return onSearchClick;
            }
        }

        #endregion Commands

        #region Command Handlers

        private void OnAddClickHandler(object obj)
        {
            BlurbEditWindow window = new BlurbEditWindow();
            window.DataContext = new BlurbEditWindowViewModel(dataRepository);
            window.ShowDialog();
            UpdateSideBarTagList();
            UpdateBlurbSideBarList();
        }

        private void OnRemoveClickHandler(object obj)
        {
            if (SelectedBlurb != null)
            {
                dataRepository.DeleteBlurb(SelectedBlurb.Id);
            }
            UpdateBlurbSideBarList();
        }

        private void OnEditClickHandler(object ob)
        {
            if (SelectedBlurb != null)
            {
                BlurbEditWindow window = new BlurbEditWindow();
                window.DataContext = new BlurbEditWindowViewModel(dataRepository, SelectedBlurb);
                window.ShowDialog();
                UpdateSideBarTagList();
                UpdateBlurbSideBarList();
            }
        }

        private void OnSearchClickHandler(object obj)
        {
            UpdateBlurbSideBarList();
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
