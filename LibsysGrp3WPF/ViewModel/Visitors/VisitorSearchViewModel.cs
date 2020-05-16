using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class VisitorSearchViewModel : ManageBookViewModel, IPageViewModel
    {
        #region Privete properties
        private string _btnborrowBook;
        private ICommand _borrowBook;
        #endregion

        #region Public properties

        public string BtnBorrowBook
        {
            get
            {
                return _btnborrowBook;
            }

            set
            {
                _btnborrowBook = value;
                OnPropertyChanged(nameof(BtnBorrowBook));
            }
        }

        public ICommand BorrowBook
        {
            get
            {
                return _borrowBook ?? (_borrowBook = new RelayCommand(x =>
                {

                    BtnBorrowBook = "Lånad";
                }));
            }
        }

        public VisitorSearchViewModel()
        {
            BtnBorrowBook = "Låna";
        }


        #endregion
    }
}
