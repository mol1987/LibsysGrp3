using System;
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
        private ObservableCollection<UsersModel> _visitorList;
        private string _addiDTextBox;
        private string _addfirstnameTextBox;
        private string _addlastnameTextBox;
        private string _addpasswordTextBox;
        private string _addmobilTextBox;
        private string _addemailTextBox;


        private ICommand _btnEditVisitor;
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

        public ObservableCollection<UsersModel> VisitorList
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
                    VisitorList[listIndex].IdentityNo = AddIDTextBox;
                    VisitorList[listIndex].Firstname = AddFirstnameTextBox;
                    VisitorList[listIndex].Lastname = AddLastnameTextBox;
                    VisitorList[listIndex].PhoneNumber = AddMobilTextBox;
                    VisitorList[listIndex].Email = AddEmailTextBox;
                    VisitorList[listIndex].Password = AddPasswordTextBox;
                    VisitorList[listIndex].EditUser();

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
                    AddIDTextBox = obj.IdentityNo;
                    AddPasswordTextBox = obj.Password;
                    AddMobilTextBox = obj.PhoneNumber;
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
                        item.IdentityNo = AddIDTextBox;
                        item.Email = AddEmailTextBox;
                        item.PhoneNumber = AddMobilTextBox;
                        item.Password = AddPasswordTextBox;
                        item.Banned = false;
                        item.AddUser();
                        string str = "" + item.Firstname;
                        MessageBox.Show(str + " added.", "Added Succesfull", MessageBoxButton.OK, MessageBoxImage.Question);
                        IsOpen = false;

                        getVisitors();
                    }
                    // if there is an object to edit update changes
                    else
                    {
                        var listIndex = VisitorList.IndexOf(userToEdit);
                        VisitorList[listIndex].Firstname = AddFirstnameTextBox;
                        VisitorList[listIndex].Lastname = AddLastnameTextBox;
                        VisitorList[listIndex].Email = AddEmailTextBox;
                        VisitorList[listIndex].PhoneNumber = AddMobilTextBox;
                        VisitorList[listIndex].Password = AddPasswordTextBox;
                        VisitorList[listIndex].EditUser();
                        string str = "" + userToEdit.Firstname;
                        MessageBox.Show(str + " edited.", "Edit Succesfull", MessageBoxButton.OK, MessageBoxImage.Question);
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
                    var obj = (UsersModel)x;
                    var userIndex = VisitorList.IndexOf(obj);
                    VisitorList[userIndex].RemoveUser();
                    VisitorList.RemoveAt(userIndex);

                    string str = obj.Firstname;
                    MessageBox.Show(str + " bortagen", "Bortagen", MessageBoxButton.OK, MessageBoxImage.Question);

                }));
            }

        }




        #endregion

        public ManageVisitorsViewModel()
        {
            getVisitors();
        }

        private void getVisitors()
        {
            // gets all users and filters to all librarians.
            var repo = new LibsysRepo();
            var tempUsersList = repo.GetUsers<Users>().Where(x => x.UsersCategory == (int)UsersCategory.Visitor);
            VisitorList = UsersModel.convertToObservableCollection(tempUsersList);
        }

        #endregion

        public void Run()
        {
        }
    }

}

