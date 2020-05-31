using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class ManageUsersViewModel : BaseViewModel, IPageViewModel
    { 
         #region private properties

        #region privates
        private ICommand _buttonOk;
        private ObservableCollection<object> _userList;
        private string _addiDTextBox;
        private string _addfirstnameTextBox;
        private string _addlastnameTextBox;
        private string _addpasswordTextBox;
        private string _addmobilTextBox;
        private string _addemailTextBox;
        private bool _bannedCheckBox;
        private string _addReasonTextBox;
        private int _addUserCategoryTextBox;
        private string _searchResultat;

        private ICommand _btnDeleteUser;
        private ICommand _btnAddUser;


        private ICommand _btnOpenUsersDialog;
        private ICommand _showDialogCommand;
        private bool _isOpen = false;

        private UsersModel userToEdit = null;
        #endregion

        #region Public Properties

        /// <summary>
        /// Array that contains all of the category types 
        /// </summary>
        public string[] CbxCategoryTyp { get; set; }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }
        public string AddIDTextBox
        {
            get
            {
                return _addiDTextBox;
            }
            set
            {
                _addiDTextBox = value;
                OnPropertyChanged(nameof(AddIDTextBox));
            }
        }
        public string AddFirstnameTextBox
        {
            get
            {
                return _addfirstnameTextBox;
            }
            set
            {
                _addfirstnameTextBox = value;
                OnPropertyChanged(nameof(AddFirstnameTextBox));
            }
        }
        public string AddLastnameTextBox
        {
            get
            {
                return _addlastnameTextBox;
            }
            set
            {
                _addlastnameTextBox = value;
                OnPropertyChanged(nameof(AddLastnameTextBox));
            }
        }
        public string AddPasswordTextBox
        {
            get
            {
                return _addpasswordTextBox;
            }
            set
            {
                _addpasswordTextBox = value;
                OnPropertyChanged(nameof(AddPasswordTextBox));
            }
        }

        public string AddMobilTextBox
        {
            get
            {
                return _addmobilTextBox;
            }
            set
            {
                _addmobilTextBox = value;
                OnPropertyChanged(nameof(AddMobilTextBox));
            }
        }

        public string AddEmailTextBox
        {
            get
            {
                return _addemailTextBox;
            }
            set
            {
                _addemailTextBox = value;
                OnPropertyChanged(nameof(AddEmailTextBox));
            }
        }

        public bool BannedCheckBox
        {
            get
            {
                return _bannedCheckBox;
            }
            set
            {
                _bannedCheckBox = value;
                OnPropertyChanged(nameof(BannedCheckBox));
            }
        }

        public string AddReasonTextBox
        {
            get
            {
                return _addReasonTextBox;
            }
            set
            {
                _addReasonTextBox = value;
                OnPropertyChanged(nameof(AddReasonTextBox));
            }
        }

        public int AddUserCategoryTextBox
        {
            get
            {
                return _addUserCategoryTextBox;
            }
            set
            {
                _addUserCategoryTextBox = value;
                OnPropertyChanged(nameof(AddUserCategoryTextBox));
            }
        }


        /// <summary>
        /// Message that comes after search
        /// </summary>
        public string SearchResultatText
        {
            get
            {
                return _searchResultat;
            }
            set
            {
                _searchResultat = value;
                OnPropertyChanged(nameof(SearchResultatText));
            }
        }



        public ObservableCollection<object> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        public ICommand ButtonOk
        {
            get
            {
                return _buttonOk ?? (_buttonOk = new RelayCommand(x =>
                {
                    var listIndex = UserList.IndexOf(userToEdit);
                    ((UsersModel)UserList[listIndex]).UsersCategory = AddUserCategoryTextBox;
                    ((UsersModel)UserList[listIndex]).IdentityNO = AddIDTextBox;
                    ((UsersModel)UserList[listIndex]).Firstname = AddFirstnameTextBox;
                    ((UsersModel)UserList[listIndex]).Lastname = AddLastnameTextBox;
                    ((UsersModel)UserList[listIndex]).PhoneNumber = AddMobilTextBox;
                    ((UsersModel)UserList[listIndex]).Email = AddEmailTextBox;
                    ((UsersModel)UserList[listIndex]).Password = AddPasswordTextBox;
                    ((UsersModel)UserList[listIndex]).Banned = BannedCheckBox;
                    ((UsersModel)UserList[listIndex]).Reason = AddReasonTextBox;
                    ((UsersModel)UserList[listIndex]).EditUser();

                    getUsers();
                }));
            }
        }

        public ICommand ShowDialogCommandForEditing
        {
            get
            {
                return _showDialogCommand ?? (_showDialogCommand = new RelayCommand(x =>
                {
                    var obj = (UsersModel)x;
                    AddUserCategoryTextBox = obj.UsersCategory;
                    AddEmailTextBox = obj.Email;
                    AddFirstnameTextBox = obj.Firstname;
                    AddLastnameTextBox = obj.Lastname;
                    AddIDTextBox = obj.IdentityNO;
                    AddPasswordTextBox = obj.Password;
                    AddMobilTextBox = obj.PhoneNumber;
                    BannedCheckBox = obj.Banned;
                    AddReasonTextBox = obj.Reason;
                    IsOpen = true;

                    userToEdit = obj;
                }));
            }
        }

        /// <summary>
        /// Button command for opening visitor dialog for adding
        /// clears the object to edit and all textboxes
        /// </summary>
        public ICommand BtnOpenUsersDialog
        {
            get
            {
                return _btnOpenUsersDialog ?? (_btnOpenUsersDialog = new RelayCommand(x =>
                {
                    IsOpen = true;
                    AddUserCategoryTextBox = 0;
                    AddEmailTextBox = "";
                    AddFirstnameTextBox = "";
                    AddLastnameTextBox = "";
                    AddIDTextBox = "";
                    AddPasswordTextBox = "";
                    AddMobilTextBox = "";
                    BannedCheckBox = false;
                    AddReasonTextBox = "";
                    userToEdit = null;
                }));
            }
        }

        public ICommand BtnAddUser
        {
            get
            {
                return _btnAddUser ?? (_btnAddUser = new RelayCommand(x =>
                {
                    // if there isnt an object to edit make it so it will add instead
                    if (userToEdit == null)
                    {
                        var item = new UsersModel(new UsersProcessor(new LibsysRepo()));

                        item.JoinDate = DateTime.Now;
                        item.UsersCategory = AddUserCategoryTextBox;
                        item.Firstname = AddFirstnameTextBox;
                        item.Lastname = AddLastnameTextBox;
                        item.IdentityNO = AddIDTextBox;
                        item.Email = AddEmailTextBox;
                        item.PhoneNumber = AddMobilTextBox;
                        item.Password = AddPasswordTextBox;
                        item.Banned = false;
                        item.Reason = AddReasonTextBox;
                        item.AddUser();
                        string str = "" + item.Firstname;
                        MessageBox.Show(str + " tillagd.", "Tillagd lyckats", MessageBoxButton.OK, MessageBoxImage.Question);
                        IsOpen = false;

                        getUsers();
                    }
                    // if there is an object to edit update changes
                    else
                    {
                        var listIndex = UserList.IndexOf(userToEdit);
                        ((UsersModel)UserList[listIndex]).UsersCategory = AddUserCategoryTextBox;
                        ((UsersModel)UserList[listIndex]).Firstname = AddFirstnameTextBox;
                        ((UsersModel)UserList[listIndex]).Lastname = AddLastnameTextBox;
                        ((UsersModel)UserList[listIndex]).Email = AddEmailTextBox;
                        ((UsersModel)UserList[listIndex]).PhoneNumber = AddMobilTextBox;
                        ((UsersModel)UserList[listIndex]).Password = AddPasswordTextBox;
                        ((UsersModel)UserList[listIndex]).Banned = BannedCheckBox;
                        ((UsersModel)UserList[listIndex]).Reason = AddReasonTextBox;
                        ((UsersModel)UserList[listIndex]).EditUser();
                        string str = "" + userToEdit.Firstname;
                        MessageBox.Show(str + " redigerad.", "Redigering lyckats", MessageBoxButton.OK, MessageBoxImage.Question);
                        getUsers();
                        // toggle it to null so there is no object to change
                        IsOpen = false;
                        userToEdit = null;
                    }

                }));
            }
        }


        public ICommand BtnDeleteUser
        {
            get
            {
                return _btnDeleteUser ?? (_btnDeleteUser = new RelayCommand(x =>
                {
                    var Result = MessageBox.Show("Är du säkert att du vill ta bort denna användare?", "Ta bort användare", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (Result == MessageBoxResult.Yes)
                    {
                        var obj = (UsersModel)x;
                        var userIndex = UserList.IndexOf(obj);
                        ((UsersModel)UserList[userIndex]).RemoveUser();
                        UserList.RemoveAt(userIndex);

                        string str = obj.Firstname;
                        MessageBox.Show(str + " bortagen", "Bortagen", MessageBoxButton.OK, MessageBoxImage.Question);
                    }

                }));
            }

        }




        #endregion


        ///<summary>
        ///Bound Button Search
        /// </summary>
        public RelayCommand btnSearch { get; set; }


        /// <summary>
        /// Bound to the search key textbox
        /// </summary>
        public string SearchKey { get; set; } = "";

        /// <summary>
        /// Array that contains all of the search filters
        /// </summary>
        public string[] CbxSearchFilters { get; set; }

        /// <summary>
        /// FiltertypeID
        /// </summary>
        public int FilterTypID { get; set; }

        ///<summary>
        ///Get Multiple Bindings
        /// </summary>


        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<Users> searchResultList;
        /// <summary>
        /// Contains the search result
        /// </summary>

        public ObservableCollection<Users> SearchResultList
        {
            get => searchResultList;
            set
            {
                searchResultList = value;

                OnPropertyChanged(nameof(SearchResultList));
            }
        }
        public ManageUsersViewModel()
        {
            CbxCategoryTyp = new string[] { "Besökare", "Bibliotekariet", "Bibliotekschef" };
            getUsers();
        }

        private void getUsers()
        {
            //gets all users and filters to all librarians.
            var repo = new LibsysRepo();
            var tempUsersList = repo.GetUsers<Users>();
            UserList = UsersModel.convertToObservableCollection(tempUsersList);
        }

        #endregion

        public void run()
        {
            CbxSearchFilters = new string[] {"Alla användare", "Besökare", "Bibliotekarier", "Bibliotekschef", "Personnummer"};

            // Create the search Command
            btnSearch = new RelayCommand((o) =>
            {
                SearchItems(o);
                if (o == null)
                {
                    SearchResultatText = "Hittade inga användare, vänligen sök igen.";
                }
            });
        }

        private void SearchItems(object o)
        {
            switch (FilterTypID)
            {

                case 0:
                    {

                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchAllUsers(SearchKey));
                        UserList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;

                case 1:
                    {

                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchVisitors(SearchKey));
                        UserList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
                case 2:
                    {
                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchLibrarians(SearchKey));
                        UserList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
                case 3:
                    {
                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchCheifLibrarians(SearchKey));
                        UserList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
                case 4:
                    {
                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchAllUsersWithIdentityNO(SearchKey));
                        UserList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
            }
        }
    }

}

