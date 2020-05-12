using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class FullBooksModel : ItemsModel , IFullBooks
    {
        public IBooksProcessor Processor { get; private set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public long ISBN { get; set; }
        public string Publisher { get; set; }

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


        public static ObservableCollection<FullBooksModel> ConvertToObservableCollection(IEnumerable<IFullBooks> inData)
        {
            var booksList = new ObservableCollection<FullBooksModel>();
            foreach (var item in inData)
            {
                booksList.Add(new FullBooksModel(new BooksProcessor(new LibsysRepo()))
                {
                    Title = item.Title,
                    ItemType = item.ItemType,
                    ISBN = item.ISBN,
                    Author = item.Author,
                    Publisher = item.Publisher,
                    Category = item.Category,
                    Pages = item.Pages,
                    Price = item.Price,
                    Description = item.Description,
                    Date = item.Date

                }
                );
            }
            return booksList;
        }
    }

}
