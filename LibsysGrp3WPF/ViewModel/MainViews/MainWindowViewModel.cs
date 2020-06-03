using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;
using System.Collections.ObjectModel;
using System.Windows;
using System;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// Contains mostly code for navigation
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region private
        private ICommand _btnSignIn;
        private ICommand _menuItemsCommand;
        private ICommand _btnUserAccess;
        private ICommand _ButtonHome;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private string _iDTextBox;
        private string _passwordTextBox;
        private string _accountCategory = "";
        private string _accountName = "";
        private bool _isOpen = false;
        
        /// <summary>
        /// Dictionary for the side menu
        /// returns an obserablecollection of a list of PagesChoice that
        /// corresponds with the logged in Users category
        /// </summary>
        private Dictionary<UsersCategory, ObservableCollection<PagesChoice>> _menuListCategories = new Dictionary<UsersCategory, ObservableCollection<PagesChoice>>
        {
            {
                UsersCategory.Visitor, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageVisitorSearch,
                    PagesChoice.pageVisitorMyItems,
                    PagesChoice.pageVisitorEditProfil
                }
            },
            {
                UsersCategory.Librarian, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageManageVisitor,
                    PagesChoice.pageManageBook,
                    PagesChoice.pageReport,
                    PagesChoice.pageManageCheckIn
                }
            },
            {
                UsersCategory.Chieflibrarian, new ObservableCollection<PagesChoice>
                {
                    //PagesChoice.pageStartView,
                    PagesChoice.pageManageUsers,
                    PagesChoice.pageReport
                }
            }
        };
        private ObservableCollection<PagesChoice> _menuList = new ObservableCollection<PagesChoice>();
        #endregion

        #region properties
        /// <summary>
        /// Sign in command
        /// </summary>
        public ICommand btnSignIn
        {
            get
            {
                
                return _btnSignIn ?? (_btnSignIn = new RelayCommand(x =>
                {
                    try { 
                        Mediator.User = new UsersModel(new UsersProcessor(new LibsysRepo()));
                        Mediator.User.LoginUser(IDTextBox, PasswordEncrypt.StoredCleanPassword.ToString());
                        AccountCategory = ((UsersCategory)Mediator.User.UsersCategory).ToString();
                        AccountName = Mediator.User.Firstname + " " + Mediator.User.Lastname;

                        // Switches view to match User previlige and match menu content
                        switch ((UsersCategory)Mediator.User.UsersCategory)
                        {
                            case UsersCategory.Visitor:
                                CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageVisitorSearch];
                                MenuList = _menuListCategories[UsersCategory.Visitor];
                                AccountCategory = "Besökare";
                                break;
                            case UsersCategory.Librarian:
                                //CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageLibrarianHomepage];
                                MenuList = _menuListCategories[UsersCategory.Librarian];
                                AccountCategory = "Bibliotekarie";
                                break;
                            case UsersCategory.Chieflibrarian:
                                //CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageSuperUserHomepage];
                                MenuList = _menuListCategories[UsersCategory.Chieflibrarian];
                                AccountCategory = "Admin";
                                break;
                            default:
                           
                                break;
                        }

                        // close popup
                        IsOpen = false;
                    } catch (Exception e)
                    {
                        MessageBox.Show("Login-uppgifter stämde inte överens, försök igen.", "Login fel!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Mediator.User = null;
                    }
            }));
            }
        }
        /// <summary>
        /// Sign in button
        /// if no users has logged in open the popup
        /// if there is one, sign out user
        /// </summary>
        public ICommand BtnUserAccess
        {
            get
            {
                return _btnUserAccess ?? (_btnUserAccess = new RelayCommand(x =>
                {
                    if (Mediator.User == null)
                    {
                        IsOpen = true;
                    } else
                    {
                        var Result = MessageBox.Show("Vill du logga ut?", "Logga ut", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (Result == MessageBoxResult.Yes)
                        {
                            SignOutProcess();
                        }
                        
                    }
                }));
            }
        }

        /// <summary>
        /// Sends a PagesChoice enum from the sidemenu
        /// for easy navigation
        /// </summary>
        public ICommand MenuItemsCommand
        {
            get
            {
                return _menuItemsCommand ?? (_menuItemsCommand = new RelayCommand(x =>
                {
                    ChangeViewModel(PageViewModels[(int)((PagesChoice)x)]);
                }));
            }
        }

        /// <summary>
        /// Navigates to the first page depending on which user is logged in
        /// for easy navigation
        /// </summary>

        public ICommand ButtonHome
        {
            get
            {
                return _ButtonHome ?? (_ButtonHome = new RelayCommand(x =>
                {
                    if (Mediator.User == null)
                    {
                        ChangeViewModel(PageViewModels[(int)((PagesChoice.pageStartView))]);
                    }
                    else if (Mediator.User.UsersCategory == (int) UsersCategory.Chieflibrarian)
                    {
                        ChangeViewModel(PageViewModels[(int)((PagesChoice.pageStartView))]);
                    }

                    else if (Mediator.User.UsersCategory == (int)UsersCategory.Librarian)
                    {
                        ChangeViewModel(PageViewModels[(int)((PagesChoice.pageStartView))]);
                    }

                    else if (Mediator.User.UsersCategory == (int)UsersCategory.Visitor)
                    {
                        ChangeViewModel(PageViewModels[(int)((PagesChoice.pageVisitorSearch))]);
                    }

                }));
            }
        }

        /// <summary>
        /// The menulist of the sidemenu
        /// just a list of enums that gets converted
        /// to the right 'name'
        /// </summary>
        public ObservableCollection<PagesChoice> MenuList
        {
            get
            {
                return _menuList;
            }
            set
            {
                _menuList = value;
                OnPropertyChanged(nameof(MenuList));
            }
        }

        /// <summary>
        /// Property for the popup
        /// if true popup is open
        /// </summary>
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
        public string AccountCategory
        {
            get
            {
                return _accountCategory;
            }
            set
            {
                _accountCategory = value;
                OnPropertyChanged(nameof(AccountCategory));
            }
        }
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
                OnPropertyChanged(nameof(AccountName));
            }
        }
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

        public List<IPageViewModel> PageViewModels 
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                // Runs this method everytime the view gets changed
                _currentPageViewModel.Run();
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }
        #endregion

        /// <summary>
        /// Method to change the page
        /// </summary>
        /// <param name="viewModel"></param>
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #region Enums page assignment
        private void OnGoStartPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageStartView]);
        }

        private void OnGoPageManageVisitor(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageManageVisitor]);
        }

        private void OnGoPageReport(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageReport]);
        }

        private void OnGoBookPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageManageBook]);
        }

        private void OnGoSeminarPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageManageSeminar]);
        }
        private void OnGoManageUsersPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageManageUsers]);
        }

        private void OnGoEditProfilPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageVisitorEditProfil]);
        }

        private void OnGoVisitorMyItemsPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageVisitorMyItems]);
        }

        private void OnGoVisitorSearchPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageVisitorSearch]);
        }

        private void OnGoVisitorSeminarPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageVisitorSeminar]);
        }
        private void OnGoCheckInPage(object obj)
        {
            ChangeViewModel(PageViewModels[(int)PagesChoice.pageManageCheckIn]);
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new StartPageViewModel());
            PageViewModels.Add(new ManageVisitorsViewModel());
            PageViewModels.Add(new ReportsViewModel());
            PageViewModels.Add(new ManageBookViewModel());
            PageViewModels.Add(new ManageSeminarViewModel());
            PageViewModels.Add(new ManageUsersViewModel());
            PageViewModels.Add(new VisitorEditProfilViewModel());
            PageViewModels.Add(new VisitorMyItemsViewModel());
            PageViewModels.Add(new VisitorSearchViewModel());
            PageViewModels.Add(new VisitorSeminarViewModel());
            PageViewModels.Add(new ManageCheckInViewModel());

            CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageStartView];

            Mediator.Subscribe(PagesChoice.pageStartView, OnGoStartPage);
            Mediator.Subscribe(PagesChoice.pageManageVisitor, OnGoPageManageVisitor);
            Mediator.Subscribe(PagesChoice.pageReport, OnGoPageReport);
            Mediator.Subscribe(PagesChoice.pageManageBook, OnGoBookPage);
            Mediator.Subscribe(PagesChoice.pageManageSeminar, OnGoSeminarPage);
            Mediator.Subscribe(PagesChoice.pageManageUsers, OnGoManageUsersPage);
            Mediator.Subscribe(PagesChoice.pageVisitorEditProfil, OnGoEditProfilPage);
            Mediator.Subscribe(PagesChoice.pageVisitorMyItems, OnGoEditProfilPage);
            Mediator.Subscribe(PagesChoice.pageVisitorSearch, OnGoVisitorSearchPage);
            Mediator.Subscribe(PagesChoice.pageVisitorSeminar, OnGoVisitorSeminarPage);
            Mediator.Subscribe(PagesChoice.pageManageCheckIn, OnGoCheckInPage);
            AccountCategory = "Gäst";
        }
        #endregion

        #region methods
        /// <summary>
        /// Reset the all data.
        /// </summary>
        public void SignOutProcess()
        {
            Mediator.User = null;
            MenuList = new ObservableCollection<PagesChoice>();
            AccountCategory = "Gäst";
            AccountName = "";
            IDTextBox = "";
            PasswordTextBox = "";
            CurrentPageViewModel = PageViewModels[0];
        }
        #endregion
    }
}
