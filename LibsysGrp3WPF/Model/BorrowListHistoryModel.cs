using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BorrowListHistoryModel : IBorrowListHistory
    {
        public int BorrowListHistoryID { get; set; }
        public int StockID { get; set; }
        public int VisitorID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
