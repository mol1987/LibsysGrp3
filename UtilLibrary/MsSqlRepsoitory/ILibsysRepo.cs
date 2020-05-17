namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ILibsysRepo
    {
        public IUsers LoginUser(string identityNo, string password);
        public void AddUser(IUsers user);
        public void RemoveUser(IUsers user);
        public void EditUser(IUsers user);

        public void CreateBook(IFullBooks books);
        public void RemoveBook(IFullBooks books);
        public void EditBook(IFullBooks books);
    }
}