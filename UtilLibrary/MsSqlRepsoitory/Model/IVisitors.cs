using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IVisitors
    {
        bool Banned { get; set; }
        string Firstname { get; set; }
        string IdentityNo { get; set; }
        DateTime JoinDate { get; set; }
        string Lastname { get; set; }
        string Password { get; set; }
        int VisitorsID { get; set; }
    }
}