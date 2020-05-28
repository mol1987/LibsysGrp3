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
        public string IdentityNO { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public bool Banned { get; set; }
        public int UsersCategory { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Reason { get; set; }

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
            this.IdentityNO = tempVisitor.IdentityNO;
            this.JoinDate = tempVisitor.JoinDate;
            this.Password = tempVisitor.Password;
            this.UsersID = tempVisitor.UsersID;
            this.Email = tempVisitor.Email;
            this.PhoneNumber = tempVisitor.PhoneNumber;
            this.UsersCategory = tempVisitor.UsersCategory;
            this.Reason = tempVisitor.Reason;
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
                    IdentityNO = item.IdentityNO,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Password = item.Password,
                    Banned = item.Banned,
                    JoinDate = item.JoinDate,
                    UsersCategory = item.UsersCategory,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Reason = item.Reason
                }
                );
            }
            return usersList;
        }
        public override string ToString()
        {
            return "" + IdentityNO + ": " + Firstname + " " + Lastname;
        }
    }
}
