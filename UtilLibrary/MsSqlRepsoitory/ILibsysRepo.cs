using System.Collections.Generic;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// Just a interface to our repository
    /// so it's easy to swap out for different reasons
    /// </summary>
    public interface ILibsysRepo
    {
        public IUsers LoginUser(string identityNo, string password);
        public void AddUser(IUsers user);
        public void RemoveUser(IUsers user);
        public void EditUser(IUsers user);

        public void CreateBook(IFullBooks books);
        public void RemoveBook(IFullBooks books);
        public void EditBook(IFullBooks books);
        public IEnumerable<IStockWithBorrow> GetStock(IItems item);
        public void BorrowBook(IStockWithBorrow stock);
        public void ReserveBook(IStockWithBorrow stock);
        public void CreateItemWithStockID(IItems items);
    }
}