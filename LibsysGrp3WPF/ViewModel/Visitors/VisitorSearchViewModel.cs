using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorSearchViewModel : BaseViewModel, IPageViewModel
    {
        #region Privete properties
        private string _btnborrowBook;
        private ICommand _borrowBook;
        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<SearchItems> searchResultList;

        private ObservableCollection<FullBooksModel> _booksList;
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

        public ObservableCollection<FullBooksModel> BooksList
        {
            get => _booksList;
            set
            {
                _booksList = value;

                OnPropertyChanged(nameof(BooksList));
            }
        }
        /// <summary>
        /// Command for borrowing a specific physical book
        /// is connected with the stock list.
        /// </summary>
        public ICommand BorrowBook
        {
            get
            {
                return _borrowBook ?? (_borrowBook = new RelayCommand(x =>
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
                        // User has chosen a already reserved book
                        if (obj.SelectedStockItem.ReservationsUsersID != 0)
                        {
                            MessageBox.Show("Du måste välja en icke reserverad bok", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        // If book is not borrowed
                        if (obj.SelectedStockItem.UsersID == 0)
                        {
                            var Result = MessageBox.Show("Vill du låna boken?", "Låna", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (Result == MessageBoxResult.Yes)
                            {
                                obj.BorrowBook(Mediator.User);
                            }
                        }
                        // If book isn't borrowed and not reserved
                        else
                        {
                            var Result = MessageBox.Show("Vill du reservera boken?", "Reservera", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (Result == MessageBoxResult.Yes)
                            {
                                obj.ReserveBook(Mediator.User);
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
        public VisitorSearchViewModel()
        {
            // Search Fiter Options
            CbxSearchFilters = new string[] { "Allting", "Böker", "Online Böker", "Filmer"," Författare", "ISBN" };

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
                case 4:
                    {

                        BooksList = FullBooksModel.ConvertToObservableCollection((new LibsysRepo()).SearchBookByAuthor(SearchKey));
                    }
                    break;
                case 5:
                    {

                        BooksList = FullBooksModel.ConvertToObservableCollection((new LibsysRepo()).SearchBookByISBN(SearchKey));
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






