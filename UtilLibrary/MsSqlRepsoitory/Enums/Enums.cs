using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory.Enums
{
    /// <summary>
    /// Enum for all our StoredProcedures on the DataBase
    /// </summary>
    public enum StoredProcedures
    {
        AddNewLibrarians,
        AddNewVisitor,
        Login,
        AddUser,
        GetUsers,
        DeleteUser,
        EditUser,
        SearchBook,
        CreateBook,
        RemoveBook,
        EditBook,
        GetBook,
        GetBooks,
        RemoveItem,
        GetStock,
        BorrowItem,
        CreateItemWithStockID,
        ReserveItem,
        EditBookStatus,
        CheckInItem,
        GetUserStock
    }
}
