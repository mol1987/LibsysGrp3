using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        private ObservableCollection<ItemsModel> _borrowed;
        private ItemsModel _selectedItem;
        private ICommand _btnleaveBack;
        private ICommand _btnGetLink;
        #endregion

        #region Public properties
        public ObservableCollection<ItemsModel> borrowed
        {
            get
            {
                return _borrowed;
            }
            set
            {
                _borrowed = value;
                OnPropertyChanged(nameof(borrowed));
            }
        }
        #endregion

        #region public button commands

        // not working yet
        public ICommand btnLeaveBack
        {
            get
            {
                return _btnleaveBack ?? (_btnleaveBack = new RelayCommand(x =>
                {
                    _selectedItem.RemoveBook();
                    borrowed.Remove(_selectedItem);
                }));
            }
        }

        #endregion


        #region Constructor
        public VisitorMyItemsViewModel()
        {
            GetBorrowed();
        }
        #endregion

        private void GetBorrowed()
        {
            // gets all borrowed books..
            var repo = new LibsysRepo();
            var tempBorrowedList = repo.GetBorrowList<BorrowList>(13);
            borrowed = ItemsModel.ConvertToObservableCollection(tempBorrowedList);
        }
    }
}
