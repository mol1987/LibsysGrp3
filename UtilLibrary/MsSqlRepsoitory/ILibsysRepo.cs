namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibsysRepo
    {
        void AddNewLibrarian(ILibrarians librarian);
        void AddNewVisitor(IVisitors visitor);
    }
}