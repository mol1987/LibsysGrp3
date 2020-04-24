namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibrarians
    {
        bool CheifLibrarian { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        int LibrarianID { get; set; }
        string Password { get; set; }
    }
}