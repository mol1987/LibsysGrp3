using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class FullBooksModel : ItemsModel , IFullBooks
    {
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
