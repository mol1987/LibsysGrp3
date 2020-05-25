using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    interface IStockProcessor
    {
        public ILibsysRepo _repo { get; set; }
        public void CreateStockID(IStock stock);
    }
}
