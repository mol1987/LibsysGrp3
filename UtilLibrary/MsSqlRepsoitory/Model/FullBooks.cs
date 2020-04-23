using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class FullBooks : Items, IFullBooks
    {
        public int BooksID { get; set; }
        public DateTime Date { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
