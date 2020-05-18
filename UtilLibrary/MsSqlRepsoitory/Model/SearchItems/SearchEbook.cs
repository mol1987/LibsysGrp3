using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class SearchEbook : ISearchEbook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public string Category { get; set; }
    }
}
