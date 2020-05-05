using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Users : IUsers
    {
        public int UsersID { get; set; }
        public string IdentityNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public bool Banned { get; set; }

        public int UsersCategory { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get ; set ; }
    }

}
