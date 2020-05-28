using LibsysGrp3WPF.Model.Items;
using System.Collections.ObjectModel;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {

        #region Public properties

        public ObservableCollection<FullBorrowListModel> myBooks { get; set; } = new ObservableCollection<FullBorrowListModel>();
        public ItemsModel MySelectedItem { get; set; }

        #endregion

        #region public button commands

        // not working yet
        //public ICommand btnLeaveBack => _btnLeaveBack ?? (_btnLeaveBack = new RelayCommand(x =>
        //        {
        //            var obj = (BorrowList)x;
        //            var bookIndex = borrowed.IndexOf(obj);
        //            borrowed.RemoveAt(bookIndex);
        //            //items.RemoveAt(bookIndex);

        //            //borrowed.RemoveAt(MySelectedItem.ItemsID);
        //        }));

        #endregion


        #region Constructor
        public VisitorMyItemsViewModel()
        {
            GetBorrowed();
        }

        #endregion

        /// <summary>
        /// Run() method runs each time the program starts.
        /// </summary>
        public void run()
        {
            // Resets borrow list to null
            myBooks.Clear();

            GetBorrowed();
        }

        private void GetBorrowed()
        {
            // gets borrowed list books..

            if (Mediator.User != null)
            {
                var repo = new LibsysRepo();
                var list = repo.GetBorrowList<FullBorrowListModel>(Mediator.User.UsersID);

                foreach (var item in list)
                {
                    myBooks.Add(item);
                }

            }
        }
    }
}
