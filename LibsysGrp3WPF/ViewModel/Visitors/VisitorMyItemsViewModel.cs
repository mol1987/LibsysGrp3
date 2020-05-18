using System.Collections.ObjectModel;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties

        //private ItemsModel _selectedItem;
        private ICommand _btnLeaveBack;
        private ICommand _btnGetLink;

        #endregion

        #region Public properties

        public ObservableCollection<BorrowList> borrowed { get; set; } = new ObservableCollection<BorrowList>();
        public ObservableCollection<ItemsModel> items { get; set; } = new ObservableCollection<ItemsModel>();
        public ItemsModel MySelectedItem { get; set; }

        #endregion

        #region public button commands

        // not working yet
        public ICommand btnLeaveBack => _btnLeaveBack ?? (_btnLeaveBack = new RelayCommand(x =>
                {
                    var obj = (BorrowList)x;
                    var bookIndex = borrowed.IndexOf(obj);
                    borrowed.RemoveAt(bookIndex);
                    //items.RemoveAt(bookIndex);

                    //borrowed.RemoveAt(MySelectedItem.ItemsID);
                }));

        #endregion


        #region Constructor
        public VisitorMyItemsViewModel()
        {
            GetBorrowed();
        }

        #endregion

        public void Run()
        {
            GetBorrowed();
        }

        private void GetBorrowed()
        {
            // gets all borrowed books..

            if (Mediator.User != null)
            {
                var repo = new LibsysRepo();
                var list = repo.GetBorrowList<BorrowList>(Mediator.User.UsersID);
                var res = repo.GetBorrowList<ItemsModel>(Mediator.User.UsersID);

                foreach (var item in list)
                {
                    borrowed.Add(item);
                }
                foreach (var item in res)
                {
                    items.Add(item);
                }
            }
        }
    }
}
