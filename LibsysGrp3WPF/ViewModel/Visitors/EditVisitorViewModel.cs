using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class EditVisitorViewModel : BaseViewModel, IPageViewModel
    {
        #region privates
        private UsersModel _selectedItem;
        private ICommand _buttonOk;
        private ObservableCollection<UsersModel> _usersList;
        private string _iDTextBox;
        private string _firstnameTextBox;
        private string _lastnameTextBox;
        private string _passwordTextBox;
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
                }
            }
        }
        public ICommand ButtonOk
        {
            get
            {
                return _buttonOk ?? (_buttonOk = new RelayCommand(x =>
                {
                    var listIndex = UsersList.IndexOf(_selectedItem);
                    UsersList[listIndex].IdentityNo = IDTextBox;
                    UsersList[listIndex].Firstname = FirstnameTextBox;
                    UsersList[listIndex].Lastname = LastnameTextBox;
                    UsersList[listIndex].Password = PasswordTextBox;
                    UsersList[listIndex].EditUser();

                    // update whole list from database, a quick fix (should be fixed later)
                    var repo = new LibsysRepo();
                    UsersList = UsersModel.convertToObservableCollection(repo.GetUsers<Users>());
                }));
            }
        }
        #endregion

        public EditVisitorViewModel()
        {
            var repo = new LibsysRepo();
            UsersList = UsersModel.convertToObservableCollection(repo.GetUsers<Users>());
        }
    }
}

