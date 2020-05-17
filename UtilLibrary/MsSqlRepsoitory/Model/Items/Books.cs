using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Books : IBooks
    {
        public int ItemsID { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public Int64 ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
