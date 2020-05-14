using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BorrowList : IBorrowList
    {
        public int BorrowListID { get; set; }
        public int StockID { get; set; }
        public int UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
