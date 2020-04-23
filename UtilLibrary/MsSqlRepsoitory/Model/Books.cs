using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Books
    {
        public int BooksID { get; set; }
        public int ItemsID { get; set; }
        public DateTime Date { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
