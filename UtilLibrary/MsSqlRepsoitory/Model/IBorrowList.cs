using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IBorrowList
    {
        DateTime BorrowDate { get; set; }
        int BorrowListID { get; set; }
        DateTime DueDate { get; set; }
        int StockID { get; set; }
        int VisitorID { get; set; }
    }
}