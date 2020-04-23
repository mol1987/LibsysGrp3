using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Librarians : ILibrarians
    {
        public int LibrarianID { get; set; }
        public bool CheifLibrarian { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
