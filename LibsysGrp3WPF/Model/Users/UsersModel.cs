using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int UsersCategory { get; set; }

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
        public void AddUser()
        {
            Processor.AddUserProcess(this);
        }
        public void RemoveUser()
        {
            Processor.RemoveUserProcess(this);
        }
        public void EditUser()
        {
            Processor.EditUserProcess(this);
        }
        public static ObservableCollection<UsersModel> convertToObservableCollection(IEnumerable<IUsers> inData)
        {
            var usersList = new ObservableCollection<UsersModel>();
            foreach (var item in inData)
            {
                usersList.Add(new UsersModel(new UsersProcessor(new LibsysRepo()))
                {
                    UsersID = item.UsersID,
                    IdentityNo = item.IdentityNo,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Password = item.Password,
                    Banned = item.Banned,
                    JoinDate = item.JoinDate,
                    UsersCategory = item.UsersCategory
                }
                );
            }
            return usersList;
        }
        public override string ToString()
        {
            return "" + IdentityNo + ": " + Firstname + " " + Lastname;
        }
    }
}
