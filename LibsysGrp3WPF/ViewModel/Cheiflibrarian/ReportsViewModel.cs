using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class ReportsViewModel : ManageBookViewModel, IPageViewModel
    {
        #region Private properties
        private ICommand _saveChanges;
        #endregion

        #region Commands

        /// <summary>
        /// Command for saving the changes
        /// </summary>

        public ICommand SaveChanges
        {
            get
            {
                return _saveChanges ?? (_saveChanges = new RelayCommand(x =>
                {
                    var obj = (StockWithBorrow)x;
                    if (obj != null)
                    {
                        repo.EditBookStatus(obj);

                        string str = "" + obj.StockID;
                        MessageBox.Show("Bok ID " + str + " är uppdaterad.", "Uppdaterad", MessageBoxButton.OK, MessageBoxImage.Question);
                        getBooks();
                    }
                }));

            }

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
                        SearchResultList = new ObservableCollection<FullBooks>((new LibsysRepo()).SearchAllItemBook(SearchKey));
                        BooksList = FullBooksModel.ConvertToObservableCollection(SearchResultList);
                    }
                    break;

            }
        }




    }
}

