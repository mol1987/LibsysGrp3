namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IEbooks
    {
        string Author { get; set; }
        string Category { get; set; }
        int EbooksID { get; set; }
        int ItemsID { get; set; }
        int Pages { get; set; }
        int Size { get; set; }
    }
}