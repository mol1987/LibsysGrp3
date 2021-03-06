﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class ManageVisitorsViewModel : BaseViewModel, IPageViewModel
    {

        #region private properties

        #region privates
        private ICommand _buttonOk;
        private ObservableCollection<object> _visitorList;
        private string _addiDTextBox;
        private string _addfirstnameTextBox;
        private string _addlastnameTextBox;
        private string _addpasswordTextBox;
        private string _addmobilTextBox;
        private string _addemailTextBox;
        private bool _bannedCheckBox;
        private string _addReasonTextBox;
        private string _searchResultat;

        private ICommand _btnDeleteVisitor;
        private ICommand _btnAddVisitor;


        private ICommand _btnOpenVisitorDialog;
        private ICommand _showDialogCommand;
        private bool _isOpen = false;

        private UsersModel userToEdit = null;
        #endregion

        #region Public Properties

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

        public ObservableCollection<object> VisitorList
        {
            get
            {
                return _visitorList;
            }
            set
            {
                _visitorList = value;
                OnPropertyChanged(nameof(VisitorList));
            }
        }
   
        public ICommand ButtonOk
        {
            get
            {
                return _buttonOk ?? (_buttonOk = new RelayCommand(x =>
                {
                    var listIndex = VisitorList.IndexOf(userToEdit);
                    ((UsersModel)VisitorList[listIndex]).IdentityNO = AddIDTextBox;
                    ((UsersModel)VisitorList[listIndex]).Firstname = AddFirstnameTextBox;
                    ((UsersModel)VisitorList[listIndex]).Lastname = AddLastnameTextBox;
                    ((UsersModel)VisitorList[listIndex]).PhoneNumber = AddMobilTextBox;
                    ((UsersModel)VisitorList[listIndex]).Email = AddEmailTextBox;
                    ((UsersModel)VisitorList[listIndex]).Password = AddPasswordTextBox;
                    ((UsersModel)VisitorList[listIndex]).Banned = BannedCheckBox;
                    ((UsersModel)VisitorList[listIndex]).Reason = AddReasonTextBox;
                    ((UsersModel)VisitorList[listIndex]).EditUser();

                    getVisitors();
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
        public ICommand BtnOpenVisitorDialog
        {
            get
            {
                return _btnOpenVisitorDialog ?? (_btnOpenVisitorDialog = new RelayCommand(x =>
                {
                    IsOpen = true;
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

        public ICommand BtnAddVisitor
        {
            get
            {
                return _btnAddVisitor ?? (_btnAddVisitor = new RelayCommand(x =>
                {
                    // if there isnt an object to edit make it so it will add instead
                    if (userToEdit == null)
                    {
                        var item = new UsersModel(new UsersProcessor(new LibsysRepo()));

                        item.JoinDate = DateTime.Now;
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

                        getVisitors();
                    }
                    // if there is an object to edit update changes
                    else
                    {
                        var listIndex = VisitorList.IndexOf(userToEdit);
                        ((UsersModel)VisitorList[listIndex]).Firstname = AddFirstnameTextBox;
                        ((UsersModel)VisitorList[listIndex]).Lastname = AddLastnameTextBox;
                        ((UsersModel)VisitorList[listIndex]).Email = AddEmailTextBox;
                        ((UsersModel)VisitorList[listIndex]).PhoneNumber = AddMobilTextBox;
                        ((UsersModel)VisitorList[listIndex]).Password = AddPasswordTextBox;
                        ((UsersModel)VisitorList[listIndex]).Banned = BannedCheckBox;
                        ((UsersModel)VisitorList[listIndex]).Reason = AddReasonTextBox;
                        ((UsersModel)VisitorList[listIndex]).EditUser();
                        string str = "" + userToEdit.Firstname;
                        MessageBox.Show(str + " redigerad.", "Redigering lyckats", MessageBoxButton.OK, MessageBoxImage.Question);
                        getVisitors();
                        // toggle it to null so there is no object to change
                        IsOpen = false;
                        userToEdit = null;
                    }

                }));
            }
        }


        public ICommand BtnDeleteVisitor
        {
            get
            {
                return _btnDeleteVisitor ?? (_btnDeleteVisitor = new RelayCommand(x =>
                {
                    var Result = MessageBox.Show("Är du säkert att du vill ta bort denna användare?", "Ta bort användare", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (Result == MessageBoxResult.Yes)
                    {
                        var obj = (UsersModel)x;
                        var userIndex = VisitorList.IndexOf(obj);
                        ((UsersModel)VisitorList[userIndex]).RemoveUser();
                        VisitorList.RemoveAt(userIndex);

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
        public ManageVisitorsViewModel()
        {
            getVisitors();
        }

        private void getVisitors()
        {
            //gets all users and filters to all librarians.
            var repo = new LibsysRepo();
            var tempUsersList = repo.GetUsers<Users>().Where(x => x.UsersCategory == (int)UsersCategory.Visitor);
            VisitorList = UsersModel.convertToObservableCollection(tempUsersList);
        }

        #endregion

        public void run()
        {
            CbxSearchFilters = new string[] { "Namn", "Email", "Personnummer" };

            // Create the search Command
            btnSearch = new RelayCommand((o) =>
            {
                SearchItems(o);
                if (o == null)
                {
                    SearchResultatText = "Hittade inga besökare, vänligen sök igen.";
                }
            });
        }

        private void SearchItems(object o)
        {
            switch (FilterTypID)
            {

                case 0:
                    {

                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchUserName(SearchKey));
                        VisitorList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
                case 1:
                    {
                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchUserEmail(SearchKey));
                        VisitorList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;
                case 2:
                    {
                        SearchResultList = new ObservableCollection<Users>((new LibsysRepo()).SearchUserIdentiteyNO(SearchKey));
                        VisitorList = UsersModel.convertToObservableCollection(SearchResultList);
                    }
                    break;

            }
        }
    }

}

