using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ISearchItems
    {
        string Title { get; set; }
        string Description { get; set; }
        string ItemType { get; set; }
        string Author { get; set; }
        int Pages { get; set; }
        string Category { get; set; }
    }
}
