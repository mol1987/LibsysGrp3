using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class MockLibsysRepo : ILibsysRepo
    {
        public void AddBook(IFullBooks books)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUsers user)
        {
            return;
        }

        public void EditBook(IFullBooks books)
        {
            throw new NotImplementedException();
        }

        public void EditUser(IUsers user)
        {
            return;
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
            throw new NotImplementedException();
        }

        public void RemoveUser(IUsers user)
        {
            return;
        }
    }
}
