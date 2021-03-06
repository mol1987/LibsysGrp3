﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;
using System.Linq;
using MaterialDesignThemes.Wpf;

namespace LibsysGrp3WPF
{
    public class ManageBookViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        private ObservableCollection<object> _booksList;
        private ObservableCollection<StockModel> _stocklist;
        private ICommand _btnEditBook;
        private ICommand _btnAddStockID;
        private ICommand _btnAddBook;


        private ICommand _btnOpenBookDialog;
        private ICommand _showDialogCommand;
        private bool _isOpen = false;
        private string _searchResultat;

        private FullBooksModel objToEdit = null;
        #endregion

        #region Private properties for adding a book
        private string _txBAddTitel;
        private string _txBAddItemType;
        private long _txBAddISBN;
        private string _txBAddAuthor;
        private string _txBAddPublisher;
        private string _txBAddCategory;
        private int _txBAddPages;
        private int _txBAddPrice;
        private string _txBAddDescription;
        #endregion

        #region Private properties for editing a book
        private string _txBEditTitel;
        private string _txBEditItemType;
        private long _txBEditISBN;
        private string _txBEditAuthor;
        private string _txBEditPublisher;
        private string _txBEditCategory;
        private int _txBEditPages;
        private int _txBEditPrice;
        private string _txBEditDescription;
        #endregion

        #region Public PropertiesSearch

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

        ///<summary>
        ///Get Multiple Bindings
        /// </summary>


        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<FullBooks> searchResultList;
        /// <summary>
        /// Contains the search result
        /// </summary>

        public ObservableCollection<FullBooks> SearchResultList
        {
            get => searchResultList;
            set
            {
                searchResultList = value;

                OnPropertyChanged(nameof(SearchResultList));
            }
        }
        #endregion

        #region Public properties for adding a book

        public string TxBAddTitel
        {
            get
            {
                return _txBAddTitel;
            }
            set
            {
                _txBAddTitel = value;
                OnPropertyChanged(nameof(TxBAddTitel));
            }
        }

        public string TxBAddItemType
        {
            get
            {
                return _txBAddItemType;
            }
            set
            {
                _txBAddItemType = value;
                OnPropertyChanged(nameof(TxBAddItemType));
            }
        }

        public long TxBAddISBN
        {
            get
            {
                return _txBAddISBN;
            }
            set
            {
                _txBAddISBN = value;
                OnPropertyChanged(nameof(TxBAddISBN));
            }
        }

        public string TxBAddAuthor
        {
            get
            {
                return _txBAddAuthor;
            }
            set
            {
                _txBAddAuthor = value;
                OnPropertyChanged(nameof(TxBAddAuthor));
            }
        }

        public string TxBAddPublisher
        {
            get
            {
                return _txBAddPublisher;
            }
            set
            {
                _txBAddPublisher = value;
                OnPropertyChanged(nameof(TxBAddPublisher));
            }
        }

        public string TxBAddCategory
        {
            get
            {
                return _txBAddCategory;
            }
            set
            {
                _txBAddCategory = value;
                OnPropertyChanged(nameof(TxBAddCategory));
            }
        }

        public int TxBAddPages
        {
            get
            {
                return _txBAddPages;
            }
            set
            {
                _txBAddPages = value;
                OnPropertyChanged(nameof(TxBAddPages));
            }
        }

        public int TxBAddPrice
        {
            get
            {
                return _txBAddPrice;
            }
            set
            {
                _txBAddPrice = value;
                OnPropertyChanged(nameof(TxBAddPrice));
            }
        }

        public string TxBAddDescription
        {
            get
            {
                return _txBAddDescription;
            }
            set
            {
                _txBAddDescription = value;
                OnPropertyChanged(nameof(TxBAddDescription));
            }
        }

        #endregion

        #region Public propoerties for editing a book

        public string TxBEditTitel
        {
            get
            {
                return _txBEditTitel;
            }
            set
            {
                _txBEditTitel = value;
                OnPropertyChanged(nameof(TxBEditTitel));
            }
        }

        public string TxBEditItemType
        {
            get
            {
                return _txBEditItemType;
            }
            set
            {
                _txBEditItemType = value;
                OnPropertyChanged(nameof(TxBEditItemType));
            }
        }

        public long TxBEditISBN
        {
            get
            {
                return _txBEditISBN;
            }
            set
            {
                _txBEditISBN = value;
                OnPropertyChanged(nameof(TxBEditISBN));
            }
        }


        public string TxBEditAuthor
        {
            get
            {
                return _txBEditAuthor;
            }
            set
            {
                _txBEditAuthor = value;
                OnPropertyChanged(nameof(TxBEditAuthor));
            }
        }

        public string TxBEditPublisher
        {
            get
            {
                return _txBEditPublisher;
            }
            set
            {
                _txBEditPublisher = value;
                OnPropertyChanged(nameof(TxBEditPublisher));
            }
        }

        public string TxBEditCategory
        {
            get
            {
                return _txBEditCategory;
            }
            set
            {
                _txBEditCategory = value;
                OnPropertyChanged(nameof(TxBEditCategory));
            }
        }

        public int TxBEditPages
        {
            get
            {
                return _txBEditPages;
            }
            set
            {
                _txBEditPages = value;
                OnPropertyChanged(nameof(TxBEditPages));
            }
        }

        public int TxBEditPrice
        {
            get
            {
                return _txBEditPrice;
            }
            set
            {
                _txBEditPrice = value;
                OnPropertyChanged(nameof(TxBEditPrice));
            }
        }

        public string TxBEditDescription
        {
            get
            {
                return _txBEditDescription;
            }
            set
            {
                _txBEditDescription = value;
                OnPropertyChanged(nameof(TxBEditDescription));
            }
        }


        #endregion

        #region Other public properties

        public ObservableCollection<object> BooksList
        {
            get
            {
                return _booksList;
            }
            set
            {
                _booksList = value;
                OnPropertyChanged(nameof(BooksList));
            }
        }


        public ObservableCollection<StockModel> Stocklist
        {
            get
            {
                return _stocklist;
            }
            set
            {
                _stocklist = value;
                OnPropertyChanged(nameof(Stocklist));
            }
        }



        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        /// <summary>
        /// Message that comes after search
        /// </summary>
        public string SearchResultatText
        {
            get
            {
                return _searchResultat;
            }
            set
            {
                _searchResultat = value;
                OnPropertyChanged(nameof(SearchResultatText));
            }
        }

        public LibsysRepo repo = new LibsysRepo();

        /// <summary>
        /// List of categories collected from the database
        /// </summary>
        public List<string> Categories { get; set; } = new List<string>();
            
        #endregion

        #region Commands
        public ICommand BtnEditBook
        {
            get
            {
                return _btnEditBook ?? (_btnEditBook = new RelayCommand(x =>
                {
                    var obj = (FullBooksModel)x;                
                    if (obj != null)
                    {
                        var listIndex = BooksList.IndexOf(obj);
                        ((FullBooksModel)BooksList[listIndex]).Title = TxBEditTitel;
                        ((FullBooksModel)BooksList[listIndex]).ISBN = TxBEditISBN;
                        ((FullBooksModel)BooksList[listIndex]).Author = TxBEditAuthor;
                        ((FullBooksModel)BooksList[listIndex]).Publisher = TxBEditPublisher;
                        ((FullBooksModel)BooksList[listIndex]).Category = TxBEditCategory;
                        ((FullBooksModel)BooksList[listIndex]).Pages = TxBEditPages;
                        ((FullBooksModel)BooksList[listIndex]).Price = TxBEditPrice;
                        ((FullBooksModel)BooksList[listIndex]).Description = TxBEditDescription;
                        ((FullBooksModel)BooksList[listIndex]).ItemsID = obj.ItemsID;
                        ((FullBooksModel)BooksList[listIndex]).EditBook();
                        getBooks();
                    }
                }));
            }
        } 
        public ICommand ShowDialogCommandForEditing
        {
            get
            {
                return _showDialogCommand ?? (_showDialogCommand = new RelayCommand(x =>
                {
                    var obj = (FullBooksModel)x;
                    TxBAddTitel = obj.Title;
                    TxBAddISBN = obj.ISBN;
                    TxBAddAuthor = obj.Author;
                    TxBAddPublisher = obj.Publisher;
                    TxBAddCategory = obj.Category;
                    TxBAddPages = obj.Pages;
                    TxBAddPrice = obj.Price;
                    TxBAddDescription = obj.Description;
                    IsOpen = true;

                    objToEdit = obj;
                }));
            }
        }

        /// <summary>
        /// Button command for opening book dialog for adding
        /// clears the object to edit and all textboxes
        /// </summary>
        public ICommand BtnOpenBookDialog
        {
            get
            {
                return _btnOpenBookDialog ?? (_btnOpenBookDialog = new RelayCommand(x =>
                {
                    IsOpen = true;
                    TxBAddTitel = "";
                    TxBAddISBN = 0;
                    TxBAddAuthor = "";
                    TxBAddPublisher = "";
                    TxBAddCategory = "";
                    TxBAddPages = 0;
                    TxBAddPrice = 0;
                    TxBAddDescription = "";
                    objToEdit = null;
                }));
            }
        }

        public ICommand BtnAddBook
        {
            get
            {
                return _btnAddBook ?? (_btnAddBook = new RelayCommand(x =>
                {
                    // if there isnt an object to edit make it so it will add instead
                    if (objToEdit == null)
                    {
                        var item = new FullBooksModel(new BooksProcessor(new LibsysRepo()));

                        item.Date = DateTime.Now;
                        item.Title = TxBAddTitel;
                        item.ISBN = TxBAddISBN;
                        item.Author = TxBAddAuthor;
                        item.Publisher = TxBAddPublisher;
                        item.Category = TxBAddCategory;
                        item.Pages = TxBAddPages;
                        item.Price = TxBAddPrice;
                        item.Description = TxBAddDescription;
                        item.Available = false;
                        item.CreateBook();
                        string str = "" + item.Title;
                        MessageBox.Show(str + " tillagd.", "Ny bok tillagd", MessageBoxButton.OK, MessageBoxImage.Question);

                        getBooks();
                    } 
                    // if there is an object to edit update changes
                    else
                    {
                        var listIndex = BooksList.IndexOf(objToEdit);
                        ((FullBooksModel)BooksList[listIndex]).Title = TxBAddTitel;
                        ((FullBooksModel)BooksList[listIndex]).ISBN = TxBAddISBN;
                        ((FullBooksModel)BooksList[listIndex]).Author = TxBAddAuthor;
                        ((FullBooksModel)BooksList[listIndex]).Publisher = TxBAddPublisher;
                        ((FullBooksModel)BooksList[listIndex]).Category = TxBAddCategory;
                        ((FullBooksModel)BooksList[listIndex]).Pages = TxBAddPages;
                        ((FullBooksModel)BooksList[listIndex]).Price = TxBAddPrice;
                        ((FullBooksModel)BooksList[listIndex]).Description = TxBAddDescription;
                        ((FullBooksModel)BooksList[listIndex]).ItemsID = objToEdit.ItemsID;
                        ((FullBooksModel)BooksList[listIndex]).EditBook();
                        string str = "" + objToEdit.Title;
                        MessageBox.Show(str + " redigerad.", "Redigering lyckats", MessageBoxButton.OK, MessageBoxImage.Question);
                        getBooks();
                        // toggle it to null so there is no object to change
                        IsOpen = false;
                        objToEdit = null;
                    }
                }));
            }
        }


        public ICommand BtnAddStockID
        {
            get
            {
                return _btnAddStockID ?? (_btnAddStockID = new RelayCommand(x =>
                {
                    var obj = (FullBooksModel)x;
                    repo.CreateItemWithStockID(obj);

                    string str = "" + obj.Title;
                    MessageBox.Show("Ny fysisk exempel tillagt till " + str, "Ny fysisk exempel har lagts till", MessageBoxButton.OK, MessageBoxImage.Question);
                    getBooks();

                }));
            }

        }

        #endregion

        #region Constructor
        public ManageBookViewModel()
        {
            Categories = repo.GetBookCategories().ToList();
            //getBooks();
        }
        #endregion

        #region Methods
        private void getBooks()
        {
            //gets all books..
            var repo = new LibsysRepo();
            var tempBooksList = repo.GetBooks<FullBooks>();
            BooksList = FullBooksModel.ConvertToObservableCollection(tempBooksList);
        }


        #endregion

        public void run()
        {
            CbxSearchFilters = new string[] { "Böcker" };

            // Create the search Command
            btnSearch = new RelayCommand((o) =>
            {
                SearchItems(o);
            if (o == null)
                {
                    SearchResultatText = "Hittade inga produkter, vänligen sök igen.";
                }
            });

            //getBooks();
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

                        BooksList = FullBooksModel.ConvertToObservableCollection((new LibsysRepo()).SearchAllItemBook(SearchKey));
                    }
                    break;
            }
        }
    }
}
