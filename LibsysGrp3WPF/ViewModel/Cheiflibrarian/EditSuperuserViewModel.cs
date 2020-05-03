using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class EditSuperuserViewModel : BaseViewModel, IPageViewModel
    {
        #region privates
        private UsersModel _selectedItem;
        private ICommand _buttonOk;
        private ObservableCollection<UsersModel> _usersList;
        private string _iDTextBox;
        private string _firstnameTextBox;
        private string _lastnameTextBox;
        private string _passwordTextBox;
        private string _mobilTextBox;
        private string _emailTextBox;
        #endregion

        #region Properties
        public string IDTextBox
        {
            get
            {
                return _iDTextBox;
            }
            set
            {
                _iDTextBox = value;
                OnPropertyChanged(nameof(IDTextBox));
            }
        }
        public string FirstnameTextBox
        {
            get
            {
                return _firstnameTextBox;
            }
            set
            {
                _firstnameTextBox = value;
                OnPropertyChanged(nameof(FirstnameTextBox));
            }
        }
        public string LastnameTextBox
        {
            get
            {
                return _lastnameTextBox;
            }
            set
            {
                _lastnameTextBox = value;
                OnPropertyChanged(nameof(LastnameTextBox));
            }
        }
        public string PasswordTextBox
        {
            get
            {
                return _passwordTextBox;
            }
            set
            {
                _passwordTextBox = value;
                OnPropertyChanged(nameof(PasswordTextBox));
            }
        }

        public string MobilTextBox
        {
            get
            {
                return _mobilTextBox;
            }
            set
            {
                _mobilTextBox = value;
                OnPropertyChanged(nameof(MobilTextBox));
            }
        }

        public string EmailTextBox
        {
            get
            {
                return _emailTextBox;
            }
            set
            {
                _emailTextBox = value;
                OnPropertyChanged(nameof(EmailTextBox));
            }
        }


        public ObservableCollection<UsersModel> UsersList
        {
            get
            {
                return _usersList;
            }
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }
        public UsersModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null)
                {
                    IDTextBox = _selectedItem.IdentityNo;
                    FirstnameTextBox = _selectedItem.Firstname;
                    LastnameTextBox = _selectedItem.Lastname;
                    PasswordTextBox = _selectedItem.Password;
                    MobilTextBox = _selectedItem.PhoneNumber;
                    EmailTextBox = _selectedItem.Email;
                }
            }
        }
        public ICommand ButtonOk
        {
            get
            {
                return _buttonOk ?? (_buttonOk = new RelayCommand(x =>
                {
                    if (_selectedItem != null)
                    {
                        var listIndex = UsersList.IndexOf(_selectedItem);
                        UsersList[listIndex].IdentityNo = IDTextBox;
                        UsersList[listIndex].Firstname = FirstnameTextBox;
                        UsersList[listIndex].Lastname = LastnameTextBox;
                        UsersList[listIndex].PhoneNumber = MobilTextBox;
                        UsersList[listIndex].Email = EmailTextBox;
                        UsersList[listIndex].Password = PasswordTextBox;
                        UsersList[listIndex].EditUser();

                        getSuperuser();
                    }
                }));
            }
        }
        #endregion

        public EditSuperuserViewModel()
        {
            getSuperuser();
        }

        private void getSuperuser()
        {
            // gets all users and filters to all librarians.
            var repo = new LibsysRepo();
            var tempUsersList = repo.GetUsers<Users>().Where(x => x.UsersCategory == (int)UsersCategory.Chieflibrarian);
            UsersList = UsersModel.convertToObservableCollection(tempUsersList);
        }
    }
}
