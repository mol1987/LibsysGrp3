using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class FullBooks : Items, IFullBooks
    {

        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public long ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
