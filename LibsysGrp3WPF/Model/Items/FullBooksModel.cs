using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// Model for our Books. Has alot of functionality bound with
    /// our repository for easy bindings.
    /// </summary>
    public class FullBooksModel : ItemsModel, IFullBooks, INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public IBooksProcessor Processor { get; private set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public long ISBN { get; set; }
        public string Publisher { get; set; }
        public ObservableCollection<IStockWithBorrow> _stockItems = new ObservableCollection<IStockWithBorrow>();
        private IStockWithBorrow _selectedStockItem;

        /// <summary>
        /// Property when user selects a specific book
        /// </summary>
        public IStockWithBorrow SelectedStockItem 
        { 
            get => _selectedStockItem;
            set
            {
                _selectedStockItem = value;

                OnPropertyChanged(nameof(SelectedStockItem));
            }
        }
        /// <summary>
        /// List of physical books
        /// </summary>
        public ObservableCollection<IStockWithBorrow> StockItems 
        { 
            get => _stockItems; 
            set
            {
                _stockItems = value;

                OnPropertyChanged(nameof(StockItems));
            }
       }
        #endregion

        #region Constructor
        public FullBooksModel(IBooksProcessor processor)
        {
            Processor = processor;
        }
        #endregion

        #region Methods
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
        /// Adds user and the corresponding stock to
        /// borrowlist
        /// </summary>
        /// <param name="user">Borrowing user</param>
        public void BorrowBook(IUsers user)
        {
            // update the stock item from the list so it updates on the UI
            var stockIndex = StockItems.IndexOf(SelectedStockItem);
            var date = DateTime.Now;

            var stock = new StockWithBorrow
            {
                StockID = StockItems[stockIndex].StockID,
                BorrowDate = date,
                DueDate = date.AddMonths(1),
                UsersID = user.UsersID,
                ItemsID = StockItems[stockIndex].ItemsID
            };

            // don't know why I have to do this shit to update on the UI
            StockItems.RemoveAt(stockIndex);
            StockItems.Insert(stockIndex, stock);
            //OnPropertyChanged(nameof(StockItems));

            Processor.BorrowBookProcess(StockItems[stockIndex]);
        }
        /// <summary>
        /// Puts a entry in the Reservation Table
        /// with the Users and a Stock Object
        /// Reserves a book
        /// </summary>
        /// <param name="user">Reserving user</param>
        public void ReserveBook(IUsers user)
        {
            // update the stock item from the list so it updates on the UI
            var stockIndex = StockItems.IndexOf(SelectedStockItem);

            var stock = new StockWithBorrow
            {
                StockID = StockItems[stockIndex].StockID,
                ReservationsUsersID = user.UsersID,
                UsersID = user.UsersID,
                ItemsID = StockItems[stockIndex].ItemsID,
                BorrowDate = StockItems[stockIndex].BorrowDate,
                DueDate = StockItems[stockIndex].DueDate,
                Available = StockItems[stockIndex].Available,
                Reason = StockItems[stockIndex].Reason
            };

            // don't know why I have to do this shit to update on the UI
            StockItems.RemoveAt(stockIndex);
            StockItems.Insert(stockIndex, stock);
            //OnPropertyChanged(nameof(StockItems));

            Processor.ReserveBookProcess(StockItems[stockIndex]);
        }

        /// <summary>
        /// Converts a list of FullBook items to a observablecollection
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
                var stockList = booksItem.Processor._repo.GetStock(booksItem);
                foreach (var stock in stockList)
                {
                    booksItem.StockItems.Add(stock);
                }
            }
            return booksList;
        }
        #endregion

        #region PropertyChanged
        protected void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
        #endregion
    }

}
