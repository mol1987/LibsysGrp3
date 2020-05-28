using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// Interface that has information about stock status of the specific object
    /// in the Items table. Basicly has info availability, reservation status
    /// and dates.
    /// </summary>
    public interface IStockWithBorrow : IStock
    {
        DateTime BorrowDate { get; set; }
        DateTime DueDate { get; set; }
        int UsersID { get; set; }
        int ReservationsUsersID { get; set; }
        public int BorrowListID { get; set; }
    }
}