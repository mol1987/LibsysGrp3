using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IBooks
    {
        string Author { get; set; }
        int BooksID { get; set; }
        string Category { get; set; }
        DateTime Date { get; set; }
        int ItemsID { get; set; }
        int Pages { get; set; }
    }
}