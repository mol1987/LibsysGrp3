using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UtilLibrary.MsSqlRepsoitory;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace LibsysGrp3WPF
{
    public class ManageCheckInViewModel : BaseViewModel, IPageViewModel
    {
        #region Privete properties
        private string _btnborrowBook;
        private ICommand _checkInItem;
        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<SearchItems> searchResultList;

        private ObservableCollection<object> _booksList;
        private ObservableCollection<object> _usersList;
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
        public int FilterTypID { get; set; }

        ///<summary>
        ///Get Multiple Bindings
        /// </summary>
        /// 
        public ObservableCollection<object> BooksList
        {
            get => _booksList;
            set
            {
                _booksList = value;                
                OnPropertyChanged(nameof(BooksList));
            }
        }

        public ObservableCollection<object> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;            
                OnPropertyChanged(nameof(UsersList));
            }
        }
        /// <summary>
        /// Command for borrowing a specific physical book
        /// is connected with the stock list.
        /// </summary>
        public ICommand CheckInItem
        {
            get
            {
                return _checkInItem ?? (_checkInItem = new RelayCommand(x =>
                {
                    // If it's a book
                    if (x is FullBooksModel)
                    {
                        var obj = (FullBooksModel)x;
                        if (obj != null)
                        {
                            // User hasn't chosen a book
                            if (obj.SelectedStockItem == null)
                            {
                                MessageBox.Show("Du måste välja en fysisk bok", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                return;
                            }
                            // If book is not borrowed
                            if (obj.SelectedStockItem.UsersID == 0)
                            {
                                MessageBox.Show("Boken är redan i lagret", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                return;
                            }
                            // If book is valid to be checked in
                            else
                            {
                                var Result = MessageBox.Show("Vill du återlämna boken?", "Återlämna", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (Result == MessageBoxResult.Yes)
                                {
                                    obj.CheckInBook();
                                }
                            }
                        }
                    }
                    // if it's a user
                    else if (x is UsersModel)
                    {
                        var obj = (UsersModel)x;
                        if (obj != null)
                        {
                            // User hasn't chosen a book
                            if (obj.SelectedStockItem == null)
                            {
                                MessageBox.Show("Du måste välja en fysisk bok", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                return;
                            }
                            // If book is valid to be checked in
                            else
                            {
                                var Result = MessageBox.Show("Vill du återlämna boken?", "Återlämna", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (Result == MessageBoxResult.Yes)
                                {
                                    obj.CheckInItem();
                                }
                            }
                        }
                    }
                }));
            }
        }
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
        #endregion
        #region Constructor
        public ManageCheckInViewModel()
        {
            // Search Fiter Options
            CbxSearchFilters = new string[] { "Allting", "Böcker", "Online Böker", "Filmer", "Användare" };

            // Create the search Command
            btnSearch = new RelayCommand((o) => SearchItems(o));

            getBooks();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets all books and inserts them to BooksList and displays them to UI
        /// </summary>
        private void getBooks()
        {
            // gets all books..
            var repo = new LibsysRepo();
            var tempBooksList = repo.GetBooks<FullBooks>();
            BooksList = FullBooksModel.ConvertToObservableCollection(tempBooksList);
            UsersList = null;
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
                        // empty userslist
                        UsersList = null;

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
                case 4:
                    {
                        // empty bookslist
                        BooksList = null;

                        UsersList = UsersModel.convertToObservableCollection((new LibsysRepo()).SearchUserName(SearchKey));
                    }
                    break;

            }
        }

        public void run()
        {
            getBooks();
        }
        #endregion
    }
}
