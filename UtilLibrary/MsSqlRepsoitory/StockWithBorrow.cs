using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class StockWithBorrow : IStock
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public bool Available { get; set; }
        public string Reason { get; set; }

    }
}
