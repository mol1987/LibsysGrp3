using System;

namespace LibsysGrp3WPF.Model.Items
{

    // This class is a model for users borrow list with properties from 
    // Items and BorrowList model classes.

    public class FullBorrowListModel
    {
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
