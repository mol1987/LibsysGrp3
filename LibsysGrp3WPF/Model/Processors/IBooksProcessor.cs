using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// Every process that is involved with a book object
    /// is defined here. So every functionality that is 
    /// connected to a book is defined here. Usualy connected
    /// to database.
    /// </summary>
    public interface IBooksProcessor
    {
        public ILibsysRepo _repo { get; set; }
        public void CreateBookProcess(IFullBooks books);
        public void RemoveBookProcess(IFullBooks books);
        public void EditBookProcess(IFullBooks books);
        public void EditBookStatusProcess(IStock stock);
        public void BorrowBookProcess(IStockWithBorrow stock);
        public void ReserveBookProcess(IStockWithBorrow stock);
    }
}
