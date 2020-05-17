using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties
        //private ObservableCollection<BorrowListModel> _borrowed;
        private ItemsModel _selectedItem;
        private ICommand _btnleaveBack;
        private ICommand _btnGetLink;
        #endregion

        //#region Public properties
        //public ObservableCollection<BorrowListModel> borrowed
        //{
        //    get
        //    {
        //        return _borrowed;
        //    }
        //    set
        //    {
        //        _borrowed = value;
        //        OnPropertyChanged(nameof(borrowed));
        //    }
        //}
        //#endregion

        #region Public properties
        public ObservableCollection<BorrowList> borrowed { get; set; } = new ObservableCollection<BorrowList>();
        public ObservableCollection<ItemsModel> items { get; set; } = new ObservableCollection<ItemsModel>();
        #endregion

        #region public button commands

        // not working yet
        public ICommand btnLeaveBack
        {
            get
            {
                return _btnleaveBack ?? (_btnleaveBack = new RelayCommand(x =>
                {
                    //_selectedItem.RemoveBook();
                    //borrowed.Remove(_selectedItem);
                }));
            }
        }

        #endregion


        #region Constructor
        public VisitorMyItemsViewModel()
        {
            DataTable datatable = GetTable();
            //var dataRow = datatable.AsEnumerable().Where(x => x.Field<int>("Id") == 2).FirstOrDefault();

            var dataRow = (from item in datatable.AsEnumerable()
                           where item.Field<string>("IdentityNO") == "198001011234"
                           select item).First();

            GetBorrowed();
        }

        private DataTable GetTable()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("IdentityNO", typeof(string));
            datatable.Columns.Add("UsersID", typeof(int));

            datatable.Rows.Add("198001011234", 20);
            datatable.Rows.Add("198002021234", 21);

            return datatable;
        }
        #endregion

        //private void GetBorrowed()
        //{
        //    // gets all borrowed books..
        //    var repo = new LibsysRepo();
        //    var tempBorrowedList = repo.GetBorrowList<BorrowList>(int userID);
        //    borrowed = BorrowListModel.ConvertToObservableCollection(tempBorrowedList);
        //}

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
