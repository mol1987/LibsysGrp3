using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IBorrowListHistory
    {
        DateTime BorrowDate { get; set; }
        int BorrowListHistoryID { get; set; }
        DateTime DueDate { get; set; }
        DateTime ReturnDate { get; set; }
        int StockID { get; set; }
        int VisitorID { get; set; }
    }
}