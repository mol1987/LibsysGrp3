using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class StockWithBorrow : IStockWithBorrow
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public bool Available { get; set; }
        public string Reason { get; set; }

        // borrowlist prop
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UsersID { get; set; }
    }
}
