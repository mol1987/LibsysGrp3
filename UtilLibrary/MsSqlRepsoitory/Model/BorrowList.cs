﻿using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class BorrowList : IBorrowList
    {
        public int BorrowListID { get; set; }
        public int StockID { get; set; }
        public int VisitorID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
