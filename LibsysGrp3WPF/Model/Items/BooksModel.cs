﻿

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BooksModel : IBooks
    {
        public int ItemsID { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public string Publisher { get ; set; }
    }
}
