using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class FullEbooksModel : ItemsModel, IFullEbooks
    {
        public int EbooksID { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
