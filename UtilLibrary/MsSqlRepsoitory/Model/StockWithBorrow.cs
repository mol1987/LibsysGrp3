using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// Class that has information about stock status of the specific object
    /// in the Items table. Basicly has info availability, reservation status
    /// and dates.
    /// </summary>
    public class StockWithBorrow : IStockWithBorrow
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public bool Available { get; set; }
        public string Reason { get; set; }

        // borrowlist prop
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public int UsersID { get; set; }

        // Reservations usersID, if a user has reserverd a book this is the ID of that user
        public int ReservationsUsersID { get; set; }

        /// <summary>
        /// Overrides the class tostring method to print out
        /// information about the status of the book
        /// </summary>
        /// <returns>String with book information</returns>
        public override string ToString()
        {
            string retStr = "";
            if (UsersID != 0) {
                if (ReservationsUsersID == 0)
                    retStr = "Ex. " + StockID + ". Lånad. Är tillbaka " + DueDate;
                else
                    retStr = "Ex. " + StockID + ". Lånad. Är tillbaka " + DueDate + " (Reserverad)";
            } else
            {
                retStr = "Ex. " + StockID + ". Finns.";
            }
            return retStr;
        }
    }
}
