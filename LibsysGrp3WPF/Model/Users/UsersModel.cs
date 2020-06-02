using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class UsersModel : IUsers, INotifyPropertyChanged
    {
        #region Privates
        private ObservableCollection<IStockWithBorrow> _stockItems = new ObservableCollection<IStockWithBorrow>();
        private IStockWithBorrow _selectedStockItem;
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public IUsersProcessor Processor { get; private set; }
        public int UsersID { get; set; }
        public string IdentityNO { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public bool Banned { get; set; }
        public int UsersCategory { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Reason { get; set; }

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
        /// List of physical books in our stock table.
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

        public UsersModel(IUsersProcessor processor)
        {
            Processor = processor;
        }

        /// <summary>
        /// Code for handling user login.
        /// </summary>
        /// <param name="IdentityNo">A visitors Identity number</param>
        /// <param name="Password">A password string</param>
        public void LoginUser(string IdentityNo, string Password)
        {
                var tempVisitor = Processor.LoginUsersProcess(IdentityNo, Password);
                this.Firstname = tempVisitor.Firstname;
                this.Lastname = tempVisitor.Lastname;
                this.Banned = tempVisitor.Banned;
                this.IdentityNO = tempVisitor.IdentityNO;
                this.JoinDate = tempVisitor.JoinDate;
                this.Password = tempVisitor.Password;
                this.UsersID = tempVisitor.UsersID;
                this.Email = tempVisitor.Email;
                this.PhoneNumber = tempVisitor.PhoneNumber;
                this.UsersCategory = tempVisitor.UsersCategory;
                this.Reason = tempVisitor.Reason;
            
        }
        public void AddUser()
        {
            Processor.AddUserProcess(this);
        }
        public void RemoveUser()
        {
            Processor.RemoveUserProcess(this);
        }
        public void EditUser()
        {
            Processor.EditUserProcess(this);
        }
        /// <summary>
        /// Chec
        /// </summary>
        public void CheckInItem()
        {
            // Check In process to database
            Processor.CheckInItemProcess(SelectedStockItem);

            // remove from list
            StockItems.Remove(SelectedStockItem);

        }

        /// <summary>
        /// This converts a list from the Database to a Obseservable Collection. Used in wpf.
        /// Also collects a list for every entry that contains every actual physical book connected the the
        /// user object, from the Stock table.
        /// </summary>
        /// <param name="inData">The list to be converted</param>
        /// <returns>An ObservableCollection of a user. Also connected books to the user.</returns>
        public static ObservableCollection<object> convertToObservableCollection(IEnumerable<IUsers> inData)
        {
            var usersList = new ObservableCollection<object>();
            foreach (var item in inData)
            {
                usersList.Add(new UsersModel(new UsersProcessor(new LibsysRepo()))
                {
                    UsersID = item.UsersID,
                    IdentityNO = item.IdentityNO,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Password = item.Password,
                    Banned = item.Banned,
                    JoinDate = item.JoinDate,
                    UsersCategory = item.UsersCategory,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Reason = item.Reason
                }
                );

                // add all stockitems to the user
                var usersItem = (UsersModel)usersList.Last();
                var stockList = usersItem.Processor._repo.GetUserStock(usersItem);
                foreach (var stock in stockList)
                {
                    usersItem.StockItems.Add(stock);
                }
            }
            return usersList;
        }
        /// <summary>
        /// Just a simple representation of a user.
        /// </summary>
        /// <returns>String with IdentityNO and name</returns>
        public override string ToString()
        {
            return "" + IdentityNO + ": " + Firstname + " " + Lastname;
        }

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
