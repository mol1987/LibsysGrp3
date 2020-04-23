using System;

namespace LibsysGrp3WPF.Model
{
    public class Visitors
    {
        public int VisitorsID { get; set; }
        public string IdentityNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public ushort Banned { get; set; }
    }
}
