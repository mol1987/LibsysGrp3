using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class ReportsViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        private ObservableCollection<FullBooksModel> _booksList;
        private string _selectedReason;
        #endregion

        #region Public Properties
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

        public string SelectedReason
        {
            get
            {
                return _selectedReason;
            }
            set
            {
                _selectedReason = value;
                OnPropertyChanged(nameof(SelectedReason));
            }
        }
        #endregion


        #region Get books method
        private void getBooks()
        {
            // gets all books..
            var repo = new LibsysRepo();
            var tempBooksList = repo.GetBooks<FullBooks>();
            BooksList = FullBooksModel.ConvertToObservableCollection(tempBooksList);
        }

        #endregion


        #region Constructor
        public ReportsViewModel()
        {
            getBooks();
        }
        #endregion

        public void run()
        {

        }
    }
}

