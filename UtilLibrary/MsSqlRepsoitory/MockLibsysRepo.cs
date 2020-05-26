using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// Just a mockup of our repository for testing purposes.
    /// </summary>
    public class MockLibsysRepo : ILibsysRepo
    {
        #region Users
        public void AddUser(IUsers user)
        {
            return;
        }
        public void EditUser(IUsers user)
        {
            return;
        }
        public IUsers LoginUser(string identityNo, string password)
        {
            return new Users()
            {
                IdentityNO = identityNo,
                Password = password,
                UsersID = 1,
                Banned = false,
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = 0,
                JoinDate = DateTime.Now
            };
        }
        public void RemoveUser(IUsers user)
        {
            return;
        }
        #endregion
        #region Items
        public void BorrowBook(IStockWithBorrow stock)
        {
            return;
        }
        public void CreateBook(IFullBooks books)
        {
            return;
        }
        public void CreateItemWithStockID(IItems items)
        {
            return;
        }
        public void EditBook(IFullBooks books)
        {
            return;
        }
        public IEnumerable<IStockWithBorrow> GetStock(IItems item)
        {
            return null;
        }
        public void RemoveBook(IFullBooks books)
        {
            return;
        }
        public void ReserveBook(IStockWithBorrow stock)
        {
            return;
        }
        public void EditBookStatus(IStock stock)
        {
            return;
        }
        #endregion
    }
}
