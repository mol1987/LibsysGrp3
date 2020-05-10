using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageBookViewModel : BaseViewModel, IPageViewModel
    {
        #region privates
        private UsersModel _booklist;
        private ICommand _btnEditBook;
        private ICommand _btnDeleteBook;
        private ICommand _btnAddEbok; 
        private ICommand _btnAddBook;

        private int _itemTypeTextBox; 
        private int _ISBNTextBox;
        private string _authorTextBox;
        private string _titelTextBox;
        private string _publisherTextBox;
        //private int _releaseYearTextBox;
        private string _categoryTextBox;
        private int _pagesTextBox;
        private int _priceTextBox;
        private string _descriptionTextBox;
        #endregion

        #region public properties

        public int ItemTypeTextBox
        {
            get
            {
                return _itemTypeTextBox;
            }
            set
            {
                _itemTypeTextBox = value;
                OnPropertyChanged(nameof(ItemTypeTextBox));
            }
        }

        public int ISBNTextBox
        {
            get
            {
                return _ISBNTextBox;
            }
            set
            {
                _ISBNTextBox = value;
                OnPropertyChanged(nameof(ISBNTextBox));
            }
        }

        public string AuthorTextBox
        {
            get
            {
                return _authorTextBox;
            }
            set
            {
                _authorTextBox = value;
                OnPropertyChanged(nameof(AuthorTextBox));
            }
        }

        public string TitelTextBox
        {
            get
            {
                return _titelTextBox;
            }
            set
            {
                _titelTextBox = value;
                OnPropertyChanged(nameof(TitelTextBox));
            }
        }

        public string PublisherTextBox
        {
            get
            {
                return _publisherTextBox;
            }
            set
            {
                _publisherTextBox = value;
                OnPropertyChanged(nameof(PublisherTextBox));
            }
        }

        //public int ReleaseYearTextBox
        //{
        //    get
        //    {
        //        return _releaseYearTextBox;
        //    }
        //    set
        //    {
        //        _releaseYearTextBox = value;
        //        OnPropertyChanged(nameof(ReleaseYearTextBox));
        //    }
        //}

        public string CategoryTextBox
        {
            get
            {
                return _categoryTextBox;
            }
            set
            {
                _categoryTextBox = value;
                OnPropertyChanged(nameof(CategoryTextBox));
            }
        }

        public int PagesTextBox
        {
            get
            {
                return _pagesTextBox;
            }
            set
            {
                _pagesTextBox = value;
                OnPropertyChanged(nameof(PagesTextBox));
            }
        }

        public int PriceTextBox
        {
            get
            {
                return _priceTextBox;
            }
            set
            {
                _priceTextBox = value;
                OnPropertyChanged(nameof(PriceTextBox));
            }
        }

        public string DescriptionTextBox
        {
            get
            {
                return _descriptionTextBox;
            }
            set
            {
                _descriptionTextBox = value;
                OnPropertyChanged(nameof(DescriptionTextBox));
            }
        }

        public ICommand BtnEditBook;

        public ICommand BtnDeleteBook;

        public ICommand BtnAddEbok;

        public ICommand BtnAddBook;



        #endregion



    }
}
