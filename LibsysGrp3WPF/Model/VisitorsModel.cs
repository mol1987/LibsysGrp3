using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// A class where all the business logic
    /// for all users lies.
    /// </summary>
    public class VisitorsModel : IVisitors
    {
        public IVisitorsProcessor Processor { get; private set; }
        public bool Banned { get; set; }
        public string Firstname { get; set; }
        public string IdentityNo { get; set; }
        public DateTime JoinDate { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public int VisitorsID { get; set; }

        public VisitorsModel(IVisitorsProcessor processor)
        {
            Processor = processor;
        }

        public void LoginVisitor(string IdentityNo, string Password)
        {
            var tempVisitor = Processor.LoginVisitorProcess(IdentityNo, Password);
            Firstname = tempVisitor.Firstname;
            Lastname = tempVisitor.Lastname;
            Banned = tempVisitor.Banned;
            IdentityNo = tempVisitor.IdentityNo;
            JoinDate = tempVisitor.JoinDate;
            Password = tempVisitor.Password;
            VisitorsID = tempVisitor.VisitorsID;
        }
    }
}
