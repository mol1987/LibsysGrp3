namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IFullEbooks
    {
        string Author { get; set; }
        string Category { get; set; }
        int EbooksID { get; set; }
        int Pages { get; set; }
        int Size { get; set; }
    }
}