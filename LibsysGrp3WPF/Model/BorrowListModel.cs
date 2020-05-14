﻿using System;
using System.Collections.ObjectModel;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BorrowListModel : IBorrowList
    {
        public int BorrowListID { get; set; }
        public int StockID { get; set; }
        public int VisitorID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        internal static ObservableCollection<BorrowListModel> ConvertToObservableCollection(object tempBorrowedList)
        {
            throw new NotImplementedException();
        }
    }
}
