using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UtilLibrary.MsSqlRepsoitory.Enums;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// A repository for our library application.
    /// </summary>
    public class LibsysRepo : ILibsysRepo
    {
        #region privates
        private readonly string _connectionString;

        #endregion

        #region constructor
        public LibsysRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibsysAzure"].ConnectionString;
        }
        #endregion

        #region UtilMethods
        private SqlConnection Create_Connection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region Items
        public IEnumerable<SearchItems> SearchItems(string Key)
        {
            string storedProcedure = StoredProcedures.SearchItems.ToString();
            IEnumerable<SearchItems> itemList;
            using (var conn = Create_Connection())
            {
                itemList = conn.Query<SearchItems>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return itemList;
        }
        public IEnumerable<FullBooks> SearchAllItemBook(string Key)
        {
            string storedProcedure = StoredProcedures.SearchBooksAllItems.ToString();
            IEnumerable<FullBooks> itemList;
            using (var conn = Create_Connection())
            {
                itemList = conn.Query<FullBooks>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return itemList;
        }
        public IEnumerable<FullBooks> SearchBookByISBN(string Key)
        {
            string storedProcedure = StoredProcedures.SearchBookByISBN.ToString();
            IEnumerable<FullBooks> itemList;
            using (var conn = Create_Connection())
            {
                itemList = conn.Query<FullBooks>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return itemList;

        }
        public IEnumerable<FullBooks> SearchBookByAuthor(string Key)
        {
            string storedProcedure = StoredProcedures.SearchBookByAuthor.ToString();
            IEnumerable<FullBooks> itemList;
            using (var conn = Create_Connection())
            {
                itemList = conn.Query<FullBooks>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return itemList;
        }

        public IEnumerable<SearchItems> SearchBooks(string Key)
        {
            string storedProcedure = StoredProcedures.SearchBook.ToString();
            IEnumerable<SearchItems> booksList;
            using (var conn = Create_Connection())
            {
                booksList = conn.Query<SearchItems>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return booksList;
        }
        public IEnumerable<SearchItems> SearchEbooks(string Key)
        {
            string storedProcedure = StoredProcedures.SearchEbook.ToString();
            IEnumerable<SearchItems> EbookList;
            using (var conn = Create_Connection())
            {
                EbookList = conn.Query<SearchItems>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return EbookList;
        }
        public IEnumerable<SearchItems> SearchMovies(string Key)
        {
            string storedProcedure = StoredProcedures.SearchMovie.ToString();
            IEnumerable<SearchItems> moviesList;
            using (var conn = Create_Connection())
            {
                moviesList = conn.Query<SearchItems>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return moviesList;
        }

        public IEnumerable<Users> SearchUserName(string Key)
        {
            string storedProcedure = StoredProcedures.SearchUserName.ToString();
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }
        public IEnumerable<Users> SearchUserIdentiteyNO(string Key)
        {
            string storedProcedure = StoredProcedures.SearchUserIdentityNO.ToString();
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }
        public IEnumerable<Users> SearchUserEmail(string Key)
        {
            string storedProcedure = StoredProcedures.SearchUserIdentityNO.ToString();
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>(storedProcedure, new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }
        /// <summary>
        /// Get a list of books from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetBooks<T>()
        {
            string storedProcedure = StoredProcedures.GetBooks.ToString();
            IEnumerable<T> booksList;
            using (var conn = Create_Connection())
            {
                booksList = conn.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
            return booksList;
        }
        /// <summary>
        /// Just stores the specific stockid to the BorrowList table
        /// </summary>
        /// <param name="stock">Stock object thats connected to the book</param>
        public void BorrowBook(IStockWithBorrow stock)
        {
            string storedProcedure = StoredProcedures.BorrowItem.ToString();

            var obj = new
            {
                StockID = stock.StockID,
                UsersID = stock.UsersID,
                BorrowDate = stock.BorrowDate,
                DueDate = stock.DueDate
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Just stores the specific stockid to the BorrowList table
        /// </summary>
        /// <param name="stock">Stock object thats connected to the book</param>
        public void CheckInBook(IStockWithBorrow stock)
        {
            string storedProcedure = StoredProcedures.CheckInItem.ToString();

            var obj = new
            {
                BorrowListID = stock.BorrowListID,
                StockID = stock.StockID,
                UsersID = stock.UsersID,
                BorrowDate = stock.BorrowDate,
                DueDate = stock.DueDate,
                ReturnDate = DateTime.Now
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Gets all stock entries that is bind to items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable<IStockWithBorrow> GetStock(IItems item)
        {
            string storedProcedure = StoredProcedures.GetStock.ToString();
            var obj = new
            {
                ItemsID = item.ItemsID
            };

            IEnumerable<IStockWithBorrow> stockWithBorrow;
            using (var conn = Create_Connection())
            {
                stockWithBorrow = conn.Query<StockWithBorrow>(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
            return stockWithBorrow;
        }

        /// <summary>
        /// Reserves a book if it's already loaned
        /// </summary>
        /// <param name="stock">Stock object thats connected to the book</param>
        public void ReserveBook(IStockWithBorrow stock)
        {
            string storedProcedure = StoredProcedures.ReserveItem.ToString();

            var obj = new
            {
                StockID = stock.StockID,
                UsersID = stock.ReservationsUsersID,
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Creates an entry to the database,
        /// stores it in both item table and books table.
        /// </summary>
        /// <param name="books">Books object</param>
        public void CreateBook(IFullBooks books)
        {
            string storedProcedure = StoredProcedures.CreateBook.ToString();

            var obj = new
            {
                Title = books.Title,
                ISBN = books.ISBN,
                Author = books.Author,
                Publisher = books.Publisher,
                Category = books.Category,
                Pages = books.Pages,
                Price = books.Price,
                Description = books.Description,
                Date = books.Date

            };

            using (var conn = Create_Connection())
            {
                conn.Query<FullBooks>(storedProcedure, obj, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Gets the items from users borrowed list
        /// </summary>
        /// <param name="userID">Users id by login</param>
        /// <returns></returns>
        public IEnumerable<T> GetBorrowList<T>(int userID)
        {
            string storedProcedure = StoredProcedures.GetBorrowList.ToString();
            IEnumerable<T> borrowList;

            var obj = new
            {
                UserID = userID
            };

            using (var conn = Create_Connection())
            {
                borrowList = conn.Query<T>(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
            return borrowList;
        }

        public void CreateItemWithStockID(IItems item)
        {
            string storedProcedure = StoredProcedures.CreateItemWithStockID.ToString();

            var obj = new
            {
                ItemsID = item.ItemsID,
                Available = true

            };

            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);

            }

        }

        public void RemoveBook(IFullBooks books)
        {
            string storedProcedure = StoredProcedures.RemoveItem.ToString();
            var obj = new
            {
                ItemsID = books.ItemsID
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }

        }

        public void EditBook(IFullBooks books)
        {
            string storedProcedure = StoredProcedures.EditBook.ToString();
            var obj = new
            {
                Title = books.Title,
                ISBN = books.ISBN,
                Author = books.Author,
                Publisher = books.Publisher,
                Category = books.Category,
                Pages = books.Pages,
                Price = books.Price,
                Description = books.Description,
                Date = books.Date,
                ID = books.ItemsID
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        ///  Updates changes that are made in stock report
        /// </summary>
        /// <param name="stock"></param>
        public void EditBookStatus(IStock stock)
        {
            string storedProcedure = StoredProcedures.EditBookStatus.ToString();
            var obj = new
            {
                ItemsID = stock.ItemsID,
                StockID = stock.StockID,
                Available = stock.Available,
                Reason = stock.Reason
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Just get's a list of the categories we have stored for books
        /// in the BooksCategory table where we store books category SAB and DDK.
        /// </summary>
        /// <returns>A list of book categories of strings.</returns>
        public IEnumerable<string> GetBookCategories()
        {
            string storedProcedure = StoredProcedures.GetBookCategories.ToString();
            IEnumerable<string> categoryList;

            using (var conn = Create_Connection())
            {
                categoryList = conn.Query<string>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
            return categoryList;
        }
        #endregion

        #region Users
        public IUsers LoginUser(string identityNo, string password)
        {
            IUsers returnUser = null;
            string storedProcedure = StoredProcedures.Login.ToString();

            var obj = new
            {
                IdentityNo = identityNo,
                Password = password
            };

            using (var conn = Create_Connection())
            {
                returnUser = conn.Query<Users>(storedProcedure, obj, commandType: CommandType.StoredProcedure).Single();
            }

            return returnUser;
        }
        public void AddUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.AddUser.ToString();
            int affectedRows;

            var obj = new
            {
                IdentityNo = user.IdentityNO,
                Password = user.Password,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                JoinDate = user.JoinDate,
                Banned = user.Banned,
                UsersCategory = user.UsersCategory,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            using (var conn = Create_Connection())
            {
                conn.Query<Users>(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }

        }
        public IEnumerable<T> GetUsers<T>()
        {
            string storedProcedure = StoredProcedures.GetUsers.ToString();
            IEnumerable<T> usersList;
            using (var conn = Create_Connection())
            {
                usersList = conn.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
            return usersList;
        }
        public void RemoveUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.DeleteUser.ToString();
            var obj = new
            {
                UsersID = user.UsersID
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        public void EditUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.EditUser.ToString();
            var obj = new
            {
                UsersID = user.UsersID,
                IdentityNo = user.IdentityNO,
                Password = user.Password,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                JoinDate = user.JoinDate,
                Banned = user.Banned,
                UsersCategory = user.UsersCategory,
                Reason = user.Reason
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Gets all the stock items that is connected with the user
        /// </summary>
        /// <param name="user">The user object to be get all the stock items to</param>
        /// <returns>List of stock items</returns>
        public IEnumerable<IStockWithBorrow> GetUserStock(IUsers user)
        {
            string storedProcedure = StoredProcedures.GetUserStock.ToString();
            var obj = new
            {
                UsersID = user.UsersID,
            };
            IEnumerable<IStockWithBorrow> stockList;
            using (var conn = Create_Connection())
            {
                stockList = conn.Query<StockWithBorrow>(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
            return stockList;
        }

        public IEnumerable<Users> SearchLibrarians(string Key)
        {
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>("SearchLibrarians", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }

        public IEnumerable<Users> SearchVisitors(string Key)
        {
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>("SearchVisitors", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }

        public IEnumerable<Users> SearchCheifLibrarians(string Key)
        {
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>("SearchCheifLibrarians", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }

        public IEnumerable<Users> SearchAllUsers(string Key)
        {
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>("SearchAllUsers", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }

        public IEnumerable<Users> SearchAllUsersWithIdentityNO(string Key)
        {
            IEnumerable<Users> SearchUserList;
            using (var conn = Create_Connection())
            {
                SearchUserList = conn.Query<Users>("SearchAllUsersWithIdentityNO", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return SearchUserList;
        }



        #endregion

        #region Seminars
        #endregion
    }
}
