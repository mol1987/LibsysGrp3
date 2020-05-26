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
    class BooksProcessor : IBooksProcessor
    {
        #region Properties
        /// <summary>
        /// Need to be connected to a repository to work
        /// with database.
        /// </summary>
        public ILibsysRepo _repo { get; set; } = null;
        #endregion
        #region Constructor
        public BooksProcessor(ILibsysRepo repo)
        {
            _repo = repo;
        }
        #endregion
        #region Processes
        public void CreateBookProcess(IFullBooks books)
        {
            _repo.CreateBook(books);
        }
        public void EditBookProcess(IFullBooks books)
        {
            _repo.EditBook(books);
        }
        public void RemoveBookProcess(IFullBooks books)
        {
            _repo.RemoveBook(books);
        }
        public void BorrowBookProcess(IStockWithBorrow stock)
        {
            _repo.BorrowBook(stock);
        }
        public void ReserveBookProcess(IStockWithBorrow stock)
        {
            _repo.ReserveBook(stock);
        }
        #endregion
    }
}
