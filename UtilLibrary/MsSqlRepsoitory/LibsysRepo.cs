using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IEnumerable<SearchItems> itemList;
            using (var conn = Create_Connection())
            {
                itemList = conn.Query<SearchItems>("SearchItems", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return itemList;
        }


        public IEnumerable<SearchItems> SearchBooks(string Key)
        {
            IEnumerable<SearchItems> booksList;
            using (var conn = Create_Connection())
            {
                booksList = conn.Query<SearchItems>("SearchBook", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return booksList;
        }
        public IEnumerable<SearchItems> SearchEbooks(string Key)
        {
            IEnumerable<SearchItems> moviesList;
            using (var conn = Create_Connection())
            {
                moviesList = conn.Query<SearchItems>("SearchEbook", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return moviesList;
        }
        public IEnumerable<SearchItems> SearchMovies(string Key)
        {
            IEnumerable<SearchItems> moviesList;
            using (var conn = Create_Connection())
            {
                moviesList = conn.Query<SearchItems>("SearchMovie", new { Search = Key }, commandType: CommandType.StoredProcedure);
            }
            return moviesList;
        }

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
        /// Gets all stockentries that is bind to items
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

            IEnumerable <IStockWithBorrow> stockWithBorrow;
            using (var conn = Create_Connection())
            {
                stockWithBorrow = conn.Query<StockWithBorrow>(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
            return stockWithBorrow;
        }



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
                IdentityNo = user.IdentityNo,
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
                IdentityNo = user.IdentityNo,
                Password = user.Password,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                JoinDate = user.JoinDate,
                Banned = user.Banned,
                UsersCategory = user.UsersCategory
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion

        #region Seminars
        #endregion
    }
}
