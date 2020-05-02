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

        public void AddUserProcess(IUsers user)
        {
            #region DatavValidation
            // Data validation

            if (user.IdentityNo.Length != 12) throw new Exception();
            if (String.IsNullOrEmpty(user.Password)) throw new Exception();
            if (String.IsNullOrEmpty(user.Firstname)) throw new Exception();
            if (String.IsNullOrEmpty(user.Lastname)) throw new Exception();
            if (String.IsNullOrEmpty(user.IdentityNo)) throw new Exception();
            if (user.Password.Length > 50) throw new Exception();
            #endregion

            _repo.AddUser(user);
        }

        public void RemoveUserProcess(IUsers user)
        {
            #region DatavValidation
            // Data validation

            if (user.IdentityNo.Length != 12) throw new Exception();
            if (String.IsNullOrEmpty(user.Password)) throw new Exception();
            if (String.IsNullOrEmpty(user.Firstname)) throw new Exception();
            if (String.IsNullOrEmpty(user.Lastname)) throw new Exception();
            if (String.IsNullOrEmpty(user.IdentityNo)) throw new Exception();
            if (user.Password.Length > 50) throw new Exception();
            #endregion


            _repo.RemoveUser(user);
        }
        public void EditUserProcess(IUsers user)
        {
            #region DatavValidation
            // Data validation

            if (user.IdentityNo.Length != 12) throw new Exception();
            if (String.IsNullOrEmpty(user.Password)) throw new Exception();
            if (String.IsNullOrEmpty(user.Firstname)) throw new Exception();
            if (String.IsNullOrEmpty(user.Lastname)) throw new Exception();
            if (String.IsNullOrEmpty(user.IdentityNo)) throw new Exception();
            if (user.Password.Length > 50) throw new Exception();
            #endregion


            _repo.EditUser(user);
        }

    }
}
