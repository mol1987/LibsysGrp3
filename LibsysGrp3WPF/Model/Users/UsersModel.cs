using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class UsersModel : IUsers
    {
        public IUsersProcessor Processor { get; private set; }
        public int UsersID { get; set; }
        public string IdentityNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public bool Banned { get; set; }
        public int UserCategory { get; set; }

        public UsersModel(IUsersProcessor processor)
        {
            Processor = processor;
        }

        public void LoginUser(string IdentityNo, string Password)
        {
            var tempVisitor = Processor.LoginUsersProcess(IdentityNo, Password);
            this.Firstname = tempVisitor.Firstname;
            this.Lastname = tempVisitor.Lastname;
            this.Banned = tempVisitor.Banned;
            this.IdentityNo = tempVisitor.IdentityNo;
            this.JoinDate = tempVisitor.JoinDate;
            this.Password = tempVisitor.Password;
            this.UsersID = tempVisitor.UsersID;
        }
    }
}
