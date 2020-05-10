using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class Items : IItems
    {
        public int ItemsID { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
