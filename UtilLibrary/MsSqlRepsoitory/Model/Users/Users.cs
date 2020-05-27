using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Users : IUsers
    {
        public int UsersID { get; set; }
<<<<<<< HEAD
        public string IdentityNO { get; set; }
=======
        public string IdentityNO{ get; set; }
>>>>>>> c1c24bcee918236ee0a189107b7c7941c58af17c
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
