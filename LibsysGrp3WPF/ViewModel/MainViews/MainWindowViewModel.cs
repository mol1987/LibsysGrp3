using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using LibsysGrp3WPF.Views;
using UtilLibrary.MsSqlRepsoitory;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace LibsysGrp3WPF
{
    public class MainWindowViewModel : BaseViewModel
    {
        
        private ICommand _btnSignIn;
        private ICommand _menuItemsCommand;
        private ICommand _btnUserAccess;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private string _iDTextBox;
        private string _passwordTextBox;
        private string _accountCategory = "";
        private string _accountName = "";
        private bool _isOpen = false;

       

        private Dictionary<UsersCategory, ObservableCollection<PagesChoice>> _menuListCategories = new Dictionary<UsersCategory, ObservableCollection<PagesChoice>>
        {
            {
                UsersCategory.Visitor, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageVisitorSearch,
                    PagesChoice.pageVisitorMyItems,
                    PagesChoice.pageVisitorSeminar
                }
            },
            {
                UsersCategory.Librarian, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageStartView,
                    PagesChoice.pageManageLibrarian,
                    PagesChoice.pageManageVisitor,
                    PagesChoice.pageManageSeminar,
                    PagesChoice.pageManageBook,
                    PagesChoice.pageReport
                }
            },
            {
                UsersCategory.Chieflibrarian, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageStartView,
                    PagesChoice.pageManageUsers,
                    PagesChoice.pageManageLibrarian,
                    PagesChoice.pageManageSeminar,
                    PagesChoice.pageReport
                }
            }
        };
        private ObservableCollection<PagesChoice> _menuList = null;

        /// <summary>
        /// Sign in command
        /// </summary>
        public ICommand btnSignIn
        {
            get
            {
                return _btnSignIn ?? (_btnSignIn = new RelayCommand(x =>
                {
                    Mediator.User = new UsersModel(new UsersProcessor(new LibsysRepo()));
                    Mediator.User.LoginUser(IDTextBox, PasswordTextBox);
                    AccountCategory = ((UsersCategory)Mediator.User.UsersCategory).ToString();
                    AccountName = Mediator.User.Firstname + " " + Mediator.User.Lastname;

                    // Switches view to match User previlige and match menu content
                    switch ((UsersCategory)Mediator.User.UsersCategory)
                    {
                        case UsersCategory.Visitor:
                            CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageVisitorSearch];
                            MenuList = _menuListCategories[UsersCategory.Visitor];
                            break;
                        case UsersCategory.Librarian:
                            //CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageLibrarianHomepage];
                            MenuList = _menuListCategories[UsersCategory.Librarian];
                            break;
                        case UsersCategory.Chieflibrarian:
                            //CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageSuperUserHomepage];
                            MenuList = _menuListCategories[UsersCategory.Chieflibrarian];
                            break;
                        default:
                            break;
                    }

                    // close popup
                    IsOpen = false;
                }));
            }
        }
        
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
                        SignOutProcess();
                    }
                }));
            }
        }
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
                _currentPageViewModel.run();
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #region Enums page assignment
        private void OnGoPage1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoPage2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
        private void OnGoSuperuserHomePage(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void OnGoPageManageVisitor(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void OnGoPageManageLibrarian(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }

        private void OnGoPageManageSuperUser(object obj)
        {
            ChangeViewModel(PageViewModels[5]);
        }

        private void OnGoPageReport(object obj)
        {
            ChangeViewModel(PageViewModels[6]);
        }

        private void OnGoLibrarianHomePage(object obj)
        {
            ChangeViewModel(PageViewModels[7]);
        }

        private void OnGoBookPage(object obj)
        {
            ChangeViewModel(PageViewModels[8]);
        }

        private void OnGoEbookPage(object obj)
        {
            ChangeViewModel(PageViewModels[9]);
        }

        private void OnGoSeminarPage(object obj)
        {
            ChangeViewModel(PageViewModels[10]);
        }

        private void OnGoAddLibrarianPage(object obj)
        {
            ChangeViewModel(PageViewModels[11]);
        }

        private void OnGoDeleteLibrarianPage(object obj)
        {
            ChangeViewModel(PageViewModels[12]);
        }

        private void OnGoEditLibrarianPage(object obj)
        {
            ChangeViewModel(PageViewModels[13]);
        }

        private void OnGoAddVisitorPage(object obj)
        {
            ChangeViewModel(PageViewModels[14]);
        }

        private void OnGoDeleteVisitorPage(object obj)
        {
            ChangeViewModel(PageViewModels[15]);
        }

        private void OnGoEditVisitorPage(object obj)
        {
            ChangeViewModel(PageViewModels[16]);
        }

        private void OnGoManageUsersPage(object obj)
        {
            ChangeViewModel(PageViewModels[17]);
        }

        private void OnGoEditProfilPage(object obj)
        {
            ChangeViewModel(PageViewModels[18]);
        }

        private void OnGoMyItemsPage(object obj)
        {
            ChangeViewModel(PageViewModels[19]);
        }

        private void OnGoVisitorSearchPage(object obj)
        {
            ChangeViewModel(PageViewModels[20]);
        }

        private void OnGoVisitorSeminarPage(object obj)
        {
            ChangeViewModel(PageViewModels[20]);
        }


        #endregion
        
        #region Constructor
        public MainWindowViewModel()
        {
     

            // Add available pages and set page
            PageViewModels.Add(new StartPageViewModel());
            PageViewModels.Add(new VisitorsProfilePageViewModel());
            PageViewModels.Add(new SuperUserHomePageViewModel());
            PageViewModels.Add(new ManageVisitorsViewModel());
            PageViewModels.Add(new ManageLibrariansViewModel());
            PageViewModels.Add(new ManageSuperuserViewModel());
            PageViewModels.Add(new ReportsViewModel());
            PageViewModels.Add(new LibrariansHomePageViewModel());
            PageViewModels.Add(new ManageBookViewModel());
            PageViewModels.Add(new ManageEbookPageViewModel());
            PageViewModels.Add(new ManageSeminarViewModel());
            PageViewModels.Add(new AddLibrarianViewModel());
            PageViewModels.Add(new DeleteLibrarianViewModel());
            PageViewModels.Add(new EditLibrarianViewModel());
            PageViewModels.Add(new AddVisitorViewModel());
            PageViewModels.Add(new DeleteVisitorViewModel());
            PageViewModels.Add(new EditLibrarianViewModel());
            PageViewModels.Add(new ManageUsersViewModel());
            PageViewModels.Add(new VisitorEditProfilViewModel());
            PageViewModels.Add(new VisitorMyItemsViewModel());
            PageViewModels.Add(new VisitorSearchViewModel());
            PageViewModels.Add(new VisitorSeminarViewModel());


            CurrentPageViewModel = PageViewModels[6];

            Mediator.Subscribe(PagesChoice.pageStartView, OnGoPage1Screen);
            Mediator.Subscribe(PagesChoice.Page2, OnGoPage2Screen);
            Mediator.Subscribe(PagesChoice.pageSuperUserHomepage, OnGoSuperuserHomePage);
            Mediator.Subscribe(PagesChoice.pageManageVisitor, OnGoPageManageVisitor);
            Mediator.Subscribe(PagesChoice.pageManageLibrarian, OnGoPageManageLibrarian);
            Mediator.Subscribe(PagesChoice.pageManageSuperUser, OnGoPageManageSuperUser);
            Mediator.Subscribe(PagesChoice.pageReport, OnGoPageReport);
            Mediator.Subscribe(PagesChoice.pageLibrarianHomepage, OnGoLibrarianHomePage);
            Mediator.Subscribe(PagesChoice.pageManageBook, OnGoBookPage);
            Mediator.Subscribe(PagesChoice.pageManageEbook, OnGoEbookPage);
            Mediator.Subscribe(PagesChoice.pageManageSeminar, OnGoSeminarPage);
            Mediator.Subscribe(PagesChoice.pageAddLibrarian, OnGoAddLibrarianPage);
            Mediator.Subscribe(PagesChoice.pageDeleteLibrarian, OnGoDeleteLibrarianPage);
            Mediator.Subscribe(PagesChoice.pageEditLibrarian, OnGoEditLibrarianPage);
            Mediator.Subscribe(PagesChoice.pageAddVisitor, OnGoAddVisitorPage);
            Mediator.Subscribe(PagesChoice.pageDeleteVisitor, OnGoDeleteVisitorPage);
            Mediator.Subscribe(PagesChoice.pageEditVisitor, OnGoEditVisitorPage);
            Mediator.Subscribe(PagesChoice.pageManageUsers, OnGoManageUsersPage);
            Mediator.Subscribe(PagesChoice.pageVisitorEditProfil, OnGoEditProfilPage);
            Mediator.Subscribe(PagesChoice.pageVisitorMyItems, OnGoEditProfilPage);
            Mediator.Subscribe(PagesChoice.pageVisitorSearch, OnGoVisitorSearchPage);
            Mediator.Subscribe(PagesChoice.pageVisitorSeminar, OnGoVisitorSeminarPage);
        }
        #endregion

        #region Command functions

        /// <summary>
        /// Search for objects
        /// </summary>
        /// <param name="o"></param>
       

        #endregion

        #region methods
        /// <summary>
        /// Reset the all data.
        /// </summary>
        public void SignOutProcess()
        {
            var Result = MessageBox.Show("Är du säkert du vill logga ut?", "Logga ut", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Mediator.User = null;
                MenuList = null;
                AccountCategory = "";
                AccountName = "";
                CurrentPageViewModel = PageViewModels[0];
            }
         
        }
        #endregion
    }
}
