namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibsysRepo
    {
        void AddNewLibrarian(ILibrarians librarian);
        void AddNewVisitor(IVisitors visitor);
        public IUsers LoginUser(string identityNo, string password);
        public void AddUser(IUsers user);
        public void RemoveUser(IUsers user);
        public void EditUser(IUsers user);
    }
}