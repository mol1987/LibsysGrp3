using System;

namespace LibsysGrp3WPF.Model
{
    public class BorrowListHistory
    {
        public int BorrowListHistoryID { get; set; }
        public int StockID { get; set; }
        public int VisitorID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
