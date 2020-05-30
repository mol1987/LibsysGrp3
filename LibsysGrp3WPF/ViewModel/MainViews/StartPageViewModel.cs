using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// The first page a visitor sees
    /// contains just a basic search window.
    /// </summary>
    public class StartPageViewModel : ManageBookViewModel, IPageViewModel
    {
        #region Private Properties
        private ICommand _buttonPage2;
        private ICommand _buttonLogin;
        private ICommand _buttonGotoLogin;
        private ICommand _buttonQuit;

        private bool _popupIsOpen = false;
        private string _iDTextBox;
        private string _passwordTextBox;
        #endregion
        #region Public Properties

        ///<summary>
        ///Bound Button Search
        /// </summary>
        public RelayCommand btnSearch { get; set; }


        /// <summary>
        /// Bound to the search key textbox
        /// </summary>
        public string SearchKey { get; set; } = "";

        /// <summary>
        /// Array that contains all of the search filters
        /// </summary>
        public string[] CbxSearchFilters { get; set; }

        /// <summary>
        /// FiltertypeID
        /// </summary>
        public int FilterTypID { get; set; } = 1;

        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<SearchItems> searchResultList;
        /// <summary>
        /// Contains the search result
        /// </summary>
      

        public ObservableCollection<SearchItems> SearchResultList
        {
            get => searchResultList;
            set
            {
                searchResultList = value;

                OnPropertyChanged(nameof(SearchResultList));
            }
        }
        public string IDTextBox
        {
            get
            {
                return _iDTextBox;
            }
            set
            {
                _iDTextBox = value;
                OnPropertyChanged(nameof(IDTextBox));
            }
        }
        public string PasswordTextBox
        {
            get
            {
                return _passwordTextBox;
            }
            set
            {
                _passwordTextBox = value;
                OnPropertyChanged(nameof(PasswordTextBox));
            }
        }
        public bool PopupIsOpen
        {
            get
            {
                return _popupIsOpen;
            }
            set
            {
                _popupIsOpen = value;
                OnPropertyChanged(nameof(PopupIsOpen));
            }
        }
        public ICommand ButtonGotoLogin
        {
            get
            {
                return _buttonGotoLogin ?? (_buttonGotoLogin = new RelayCommand(x =>
                {
                    PopupIsOpen = true;
                }));
            }
        }
        public ICommand ButtonQuit
        {
            get
            {
                return _buttonQuit ?? (_buttonQuit = new RelayCommand(x =>
                {
                    Mediator.CloseApplication();
                }));
            }
        }
        public ICommand ButtonLogin
        {
            get
            {
                return _buttonLogin ?? (_buttonLogin = new RelayCommand(x =>
                {
                    var visitor = new UsersModel(new UsersProcessor(new LibsysRepo()));
                    visitor.LoginUser(IDTextBox, PasswordTextBox);
                    string str = "" + visitor.UsersID + ": " + visitor.Firstname + " " + visitor.Lastname + " Joined: " + visitor.JoinDate;
                    PopupIsOpen = false;
                    MessageBox.Show(str, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                }));
            }
        }
        #endregion

        #region Methods
        public void run()
        {
            CbxSearchFilters = new string[] { "Allting", "Böcker", "Online Böcker", "Filmer" };

            // Create the search Command
            btnSearch = new RelayCommand((o) => SearchItems(o));
        }
        /// <summary>
        /// Search for objects
        /// </summary>
        /// <param name="o"></param>
      
        private void SearchItems(object o)
        {
            switch (FilterTypID)
            {

                case 0:
                    {
                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchItems(SearchKey));
                    }
                    break;
                case 1:
                    {
                        BooksList = FullBooksModel.ConvertToObservableCollection((new LibsysRepo()).SearchAllItemBook(SearchKey));
                    }
                    break;
                case 2:
                    {
                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchEbooks(SearchKey));
                    }
                    break;
                case 3:
                    {

                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchMovies(SearchKey));
                    }
                    break;
            }
        }
        #endregion
    }
}
