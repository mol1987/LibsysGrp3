using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IBooks
    {
        string Author { get; set; }
        int ISBN { get; set; }
        string Category { get; set; }
        int ItemsID { get; set; }
        int Pages { get; set; }
    }
}