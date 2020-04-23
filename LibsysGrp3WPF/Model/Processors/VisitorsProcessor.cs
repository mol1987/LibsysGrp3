using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorsProcessor : IVisitorsProcessor
    {
        public VisitorsProcessor()
        {

        }
        public IVisitors LoginVisitor(string IdentityNo, string Password)
        {
            #region DatavValidation
            // Data validation
            if (IdentityNo.Length != 12) throw new Exception();
            if (String.IsNullOrEmpty(Password)) throw new Exception();
            if (Password.Length > 50) throw new Exception();
            #endregion

            IVisitors returnVisitor = mockReturnVisitor(IdentityNo, Password);

            return returnVisitor;
        }

        private VisitorsModel mockReturnVisitor(string IdentityNo, string Password)
        {
            return new VisitorsModel(new VisitorsProcessor())
            {
                Firstname = "Goran",
                Lastname = "Kropp",
                VisitorsID = 1,
                Password = Password,
                IdentityNo = IdentityNo,
                Banned = false,
                JoinDate = DateTime.Now
            };
        }
    }
}
