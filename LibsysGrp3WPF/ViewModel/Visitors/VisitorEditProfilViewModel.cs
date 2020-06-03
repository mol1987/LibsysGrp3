using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// A page for the user to change their profile.
    /// </summary>
    public class VisitorEditProfilViewModel : BaseViewModel, IPageViewModel
    {
        #region private
        private string _email = "";
        private string _password = "";
        private string _passwordConfirm = "";
        private ICommand _change;
        #endregion

        #region Public properties
        public string Email 
        {
            get { return _email; }
            set 
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                OnPropertyChanged(nameof(PasswordConfirm));
            }
        }
        /// <summary>
        /// When the user presse save his changes
        /// save to database
        /// </summary>
        public ICommand Change
        {
            get
            {
                return _change ?? (_change = new RelayCommand(x =>
                {
                    #region Data Validation
                    if (Password.IsNullOrEmpty() || PasswordConfirm.IsNullOrEmpty()) return;
                    if (Password != PasswordConfirm)
                    {
                        MessageBox.Show("Lösenorden matchar inte.", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    // email validaton, if the input email isn't correct format
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(Email);
                    if (match.Success == false)
                    {
                        MessageBox.Show("Fel Email-format", "Fel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    #endregion

                    var Result = MessageBox.Show("Vill du ändra?", "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (Result == MessageBoxResult.No)
                    {
                        return;
                    }
                    Mediator.User.Password = Password;
                    Mediator.User.Email = Email;
                    Mediator.User.EditUser(); 
                }));
            }
        }
        #endregion


        public void Run()
        {
            Password = Mediator.User.Password;
            PasswordConfirm = "";
            Email = Mediator.User.Email;
        }
    }
}
