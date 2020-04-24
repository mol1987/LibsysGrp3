namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibsysRepo
    {
        void AddNewLibrarian(ILibrarians librarian);
        void AddNewVisitor(IVisitors visitor);
        public IUsers LoginUser(string identityNo, string password);
    }
}