using System;

namespace LibsysGrp3WPF.Model
{
    public class BorrowList
    {
        public int BorrowListID { get; set; }
        public int StockID { get; set; }
        public int VisitorID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
