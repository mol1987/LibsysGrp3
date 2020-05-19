using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class MockLibsysRepo : ILibsysRepo
    {

        public void AddUser(IUsers user)
        {
            return;
        }

        public void CreateBook(IFullBooks books)
        {
            return;
        }


        public void CreateItemWithStockID(IFullBooks books)
        {
            return;
        }

        public void EditBook(IFullBooks books)
        {
            return;
        }

        public void EditUser(IUsers user)
        {
            return;
        }

        public IEnumerable<IStockWithBorrow> GetStock(IItems item)
        {
            return null;
        }

        public IUsers LoginUser(string identityNo, string password)
        {
            return new Users()
            {
                IdentityNo = identityNo,
                Password = password,
                UsersID = 1,
                Banned = false,
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = 0,
                JoinDate = DateTime.Now
            };
        }

        public void RemoveBook(IFullBooks books)
        {
            return;
        }

        public void RemoveUser(IUsers user)
        {
            return;
        }
    }
}
