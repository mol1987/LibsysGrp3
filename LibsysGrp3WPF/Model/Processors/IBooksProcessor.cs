using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IBooksProcessor
    {
        public ILibsysRepo _repo { get; set; }
        public void CreateBookProcess(IFullBooks books);
        public void RemoveBookProcess(IFullBooks books);
        public void EditBookProcess(IFullBooks books);
        public void BorrowBookProcess(IStockWithBorrow stock);
    }
}
