using System;
using System.Collections.Generic;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    class BooksProcessor : IBooksProcessor
    {
        public ILibsysRepo _repo { get; set; } = null;

        public BooksProcessor(ILibsysRepo repo)
        {
            _repo = repo;
        }

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

        public void EditBookStatusProcess(IStock stock)
        {
            _repo.EditBookStatus(stock);
        }
    }
}
