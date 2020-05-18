using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;
using System.Linq;

namespace LibsysGrp3WPF
{
    public class ManageBookViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        private ObservableCollection<FullBooksModel> _booksList;
        private FullBooksModel _selectedItem;
        private ICommand _btnEditBook;
        private ICommand _btnDeleteBook;
        private ICommand _btnAddBook;
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

        public ObservableCollection<FullBooksModel> BooksList
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

        /// <summary>
        /// For editing book
        /// </summary>
        public FullBooksModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null)
                {
                    TxBEditTitel = _selectedItem.Title;
                    TxBEditItemType = _selectedItem.ItemType;
                    TxBEditISBN = _selectedItem.ISBN;
                    TxBEditAuthor = _selectedItem.Author;
                    TxBEditPublisher = _selectedItem.Publisher;
                    TxBEditCategory = _selectedItem.Category;
                    TxBEditPages = _selectedItem.Pages;
                    TxBEditPrice = _selectedItem.Price;
                    TxBEditDescription = _selectedItem.Description;
                }
            }
        }
        #endregion

        #region Commands
        public ICommand BtnEditBook
        {
            get
            {
                return _btnEditBook ?? (_btnEditBook = new RelayCommand(x =>
                {
            if (_selectedItem != null)
            {
                var listIndex = BooksList.IndexOf(_selectedItem);
                        BooksList[listIndex].Title = TxBEditTitel;
                        BooksList[listIndex].ISBN = TxBEditISBN;
                        BooksList[listIndex].Author = TxBEditAuthor;
                        BooksList[listIndex].Publisher = TxBEditPublisher;
                        BooksList[listIndex].Category = TxBEditCategory;
                        BooksList[listIndex].Pages = TxBEditPages;
                        BooksList[listIndex].Price = TxBEditPrice;
                        BooksList[listIndex].Description = TxBEditDescription;
                        BooksList[listIndex].EditBook();

                        getBooks();
            }
                }));
            }
        } 

        public ICommand BtnAddBook
        {
            get
            {
                return _btnAddBook ?? (_btnAddBook = new RelayCommand(x =>
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

                    item.CreateBook();
                    string str = "" + item.Title;
                    MessageBox.Show(str + " added.", "Added Succesfull", MessageBoxButton.OK, MessageBoxImage.Question);

                    getBooks();
                    
                }));
            }
        }
        
        public ICommand BtnDeleteBook
        {
            get
            {
                return _btnDeleteBook ?? (_btnDeleteBook = new RelayCommand(x =>
                {
                    var obj = (FullBooksModel)x;
                    var bookIndex = BooksList.IndexOf(obj);
                    BooksList[bookIndex].RemoveBook();
                    BooksList.RemoveAt(bookIndex);
                    //_selectedItem.RemoveBook();
                    //BooksList.Remove(_selectedItem);

                    string str = obj.Title;
                    MessageBox.Show(str + " bortagen", "Bortagen", MessageBoxButton.OK, MessageBoxImage.Question);

                }));
            }

        }
        #endregion

        #region Constructor
        public ManageBookViewModel()
        {
            getBooks();
        }
        #endregion

        #region Get books method
        private void getBooks()
        {
            // gets all books..
            var repo = new LibsysRepo();
            var tempBooksList = repo.GetBooks();
            BooksList = FullBooksModel.ConvertToObservableCollection(tempBooksList);
        }

        #endregion

    }
}
