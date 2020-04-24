using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IFullBooks
    {
        string Author { get; set; }
        int BooksID { get; set; }
        string Category { get; set; }
        DateTime Date { get; set; }
        int Pages { get; set; }
    }
}