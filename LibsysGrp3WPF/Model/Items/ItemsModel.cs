using System;
using System.Collections.ObjectModel;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class ItemsModel : IItems
    {
        public int ItemsID { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set ; }
        public DateTime Date { get ; set; }
        public bool Available { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
