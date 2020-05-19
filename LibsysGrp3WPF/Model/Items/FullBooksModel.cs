using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class FullBooksModel : ItemsModel, IFullBooks
    {
        public IBooksProcessor Processor { get; private set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public long ISBN { get; set; }
        public string Publisher { get; set; }
        public ObservableCollection<IStockWithBorrow> StockItems { get; set; } = new ObservableCollection<IStockWithBorrow>();

        public FullBooksModel(IBooksProcessor processor)
        {
            Processor = processor;
        }

        public void CreateBook()
        {
            Processor.CreateBookProcess(this);
        }
        public void RemoveBook()
        {
            Processor.RemoveBookProcess(this);
        }
        public void EditBook()
        {
            Processor.EditBookProcess(this);
        }

        /// <summary>
        /// Convert a list of FullBook items to a observablecollection
        /// and adds a stock list to the item
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public static ObservableCollection<FullBooksModel> ConvertToObservableCollection(IEnumerable<IFullBooks> inData)
        {
            var booksList = new ObservableCollection<FullBooksModel>();
            foreach (var item in inData)
            {
                // get items stock-list

                booksList.Add(new FullBooksModel(new BooksProcessor(new LibsysRepo()))
                {
                    ItemsID = item.ItemsID,
                    Title = item.Title,
                    ItemType = item.ItemType,
                    ISBN = item.ISBN,
                    Author = item.Author,
                    Publisher = item.Publisher,
                    Category = item.Category,
                    Pages = item.Pages,
                    Price = item.Price,
                    Description = item.Description,
                    Date = item.Date,
                    
                }
                );

                // add all stockitems to book
                var booksItem = booksList.Last();
                //IEnumerable<IStockWithBorrow> stockList = new List<IStockWithBorrow>
                //{
                //    new StockWithBorrow()
                //    {
                //        StockID = 1,
                //        Available = true,
                //        BorrowDate = DateTime.Now,
                //        DueDate = DateTime.Now,
                //        ItemsID = 2,
                //        UsersID = 1,
                //        Reason = "no"
                //    },
                //    new StockWithBorrow()
                //    {
                //        StockID = 2,
                //        Available = true,
                //        Reason = ""
                //    }
                //};
                var stockList = booksItem.Processor._repo.GetStock(booksItem);
                foreach (var stock in stockList)
                {
                    booksItem.StockItems.Add(stock);
                }
            }
            return booksList;
        }
    }

}
