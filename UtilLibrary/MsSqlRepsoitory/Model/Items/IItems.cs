using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IItems
    {
        string Description { get; set; }
        int ItemsID { get; set; }
        string ItemType { get; set; }
        string Title { get; set; }
        int Price { get; set; }
        DateTime Date { get; set; }
        bool Available { get; set; }

    }
}