namespace UtilLibrary.MsSqlRepsoitory
{
    public class EbooksModel : IEbooks
    {
        public int EbooksID { get; set; }
        public int ItemsID { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
