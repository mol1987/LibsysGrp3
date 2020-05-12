using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageBookViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        private UsersModel _booklist;
        private ICommand _btnEditBook;
        private ICommand _btnDeleteBook;
        private ICommand _btnAddEbok; 
        private ICommand _btnAddBook;
        #endregion

        #region Private properties for adding a book
        private string _txBAddTitel; 
        private string _txBAddItemType;
        private int _txBAddISBN;
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
        private int _txBEditISBN;
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

        public int TxBAddISBN
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

        public int TxBEditISBN
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

        public ICommand BtnEditBook;

        public ICommand BtnDeleteBook;

        public ICommand BtnAddEbok;

        public ICommand BtnAddBook;



        #endregion



    }
}
