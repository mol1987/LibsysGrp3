using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IStockWithBorrow : IStock
    {
        DateTime BorrowDate { get; set; }
        DateTime DueDate { get; set; }
        int UsersID { get; set; }
    }
}