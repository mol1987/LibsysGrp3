using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class StartPageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _buttonPage2;
        private ICommand _buttonLogin;
        private ICommand _buttonGotoLogin;
        private ICommand _buttonQuit;

        private bool _popupIsOpen = false;
        private string _iDTextBox;
        private string _passwordTextBox;

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

        public bool PopupIsOpen { 
            get 
            {
                return _popupIsOpen;
            }
            set 
            {
                _popupIsOpen = value;
                OnPropertyChanged(nameof(PopupIsOpen));
            } 
        }

        public ICommand ButtonPage2
        {
            get
            {
                return _buttonPage2 ?? (_buttonPage2 = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.Page2, "");
                }));
            }
        }
        public ICommand ButtonGotoLogin
        {
            get
            {
                return _buttonGotoLogin ?? (_buttonGotoLogin = new RelayCommand(x =>
                {
                    PopupIsOpen = true;
                }));
            }
        }
        public ICommand ButtonQuit
        {
            get
            {
                return _buttonQuit ?? (_buttonQuit = new RelayCommand(x =>
                {
                    Mediator.CloseApplication();
                }));
            }
        }
        public ICommand ButtonLogin
        {
            get
            {
                return _buttonLogin ?? (_buttonLogin = new RelayCommand(x =>
                {
                    var visitor = new UsersModel(new UsersProcessor(new LibsysRepo()));
                    visitor.LoginUser(IDTextBox, PasswordTextBox);
                    string str = "" + visitor.UsersID + ": " + visitor.Firstname + " " + visitor.Lastname + " Joined: " + visitor.JoinDate;
                    PopupIsOpen = false;
                    MessageBox.Show(str, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                }));
            }
        }
    }
}
