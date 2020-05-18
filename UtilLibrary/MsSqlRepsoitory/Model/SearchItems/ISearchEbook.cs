using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ISearchEbook
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        int Pages { get; set; }
        int Size { get; set; }
        string Category { get; set; }
    }
}
