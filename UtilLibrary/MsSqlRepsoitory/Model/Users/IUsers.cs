using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IUsers
    {
        bool Banned { get; set; }
        string Firstname { get; set; }
        string IdentityNo { get; set; }
        DateTime JoinDate { get; set; }
        string Lastname { get; set; }
        string Password { get; set; }
        int UsersCategory { get; set; }
        int UsersID { get; set; }
    }
}