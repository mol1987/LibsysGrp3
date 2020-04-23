namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibsysRepo
    {
        void AddNewLibrarian(Librarian librarian);
        void AddNewVisitor(Visitor visitor);
    }
}