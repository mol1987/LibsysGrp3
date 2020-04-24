using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class UsersProcessor : IUsersProcessor
    {
        public ILibsysRepo _repo { get; set; } = null;
        public UsersProcessor(ILibsysRepo repo)
        {
            _repo = repo;
        }
        public IUsers LoginUsersProcess(string IdentityNo, string Password)
        {
            #region DatavValidation
            // Data validation

            if (IdentityNo.Length != 12) throw new Exception();
            if (String.IsNullOrEmpty(Password)) throw new Exception();
            if (String.IsNullOrEmpty(IdentityNo)) throw new Exception();
            if (Password.Length > 50) throw new Exception();
            #endregion

            IUsers returnVisitor = _repo.LoginUser(IdentityNo, Password);

            return returnVisitor;
        }

    }
}
