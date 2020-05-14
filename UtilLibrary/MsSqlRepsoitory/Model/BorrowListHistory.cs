using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BorrowListHistory : IBorrowListHistory
    {
        public int BorrowListHistoryID { get; set; }
        public int StockID { get; set; }
        public int UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
