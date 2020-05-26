using System;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class AddSuperuserViewModel : BaseViewModel, IPageViewModel
    {
        #region private members
        private ICommand _buttonAdd;

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

        public ICommand ButtonAdd
        {
            get
            {
                return _buttonAdd ?? (_buttonAdd = new RelayCommand(x =>
                {
                    var user = new UsersModel(new UsersProcessor(new LibsysRepo()));
                    user.Banned = false;
                    user.JoinDate = DateTime.Now;
                    user.UsersCategory = (int)UsersCategory.Librarian;
                    user.IdentityNo = IDTextBox;
                    user.Firstname = FirstnameTextBox;
                    user.Lastname = LastnameTextBox;
                    user.PhoneNumber = MobilTextBox;
                    user.Email = EmailTextBox;
                    user.Password = PasswordTextBox;

                    user.AddUser();
                    string str = "" + user.Firstname + " " + user.Lastname;
                    MessageBox.Show(str + " added.", "Added Succesfull", MessageBoxButton.OK, MessageBoxImage.Question);
                }));
            }
        }
        #endregion
        public void run()
        {
        }
    }
}
