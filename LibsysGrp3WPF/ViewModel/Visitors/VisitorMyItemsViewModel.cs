using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {
        private void getItems()
        {
            // gets all borrowed items for visitor.
            //var repo = new LibsysRepo();
            //var tempBorrowList = repo.GetBorrowList<BorrowList>().Where(x => x.UsersCategory == (int)UsersCategory.Visitor);
            //BorrowList = UsersModel.convertToObservableCollection(tempUsersList);
        }
    }
}
