using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class MockLibsysRepo : ILibsysRepo
    {
        public void AddNewLibrarian(ILibrarians librarian)
        {
            throw new NotImplementedException();
        }

        public void AddNewVisitor(IVisitors visitor)
        {
            throw new NotImplementedException();
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
                UserCategory = 0,
                JoinDate = DateTime.Now
            };
        }
    }
}
