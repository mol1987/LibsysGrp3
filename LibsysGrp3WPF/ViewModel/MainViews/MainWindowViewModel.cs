using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// The ViewModel for the MainWindow
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region Commands

        #region SignIn Command

        private ICommand _btnSignIn;

        public ICommand btnSignIn
        {
            get
            {
                return _btnSignIn ?? (_btnSignIn = new RelayCommand(x =>
                {
                    Mediator.User = new UsersModel(new UsersProcessor(new LibsysRepo()));
                    Mediator.User.LoginUser(IDTextBox, PasswordTextBox);
                    AccountCategory = ((UsersCategory)Mediator.User.UsersCategory).ToString();

                    // Switches view to match User previlige and match menu content
                    switch ((UsersCategory)Mediator.User.UsersCategory)
                    {
                        case UsersCategory.Visitor:
                            CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageVisitorSearch];
                            MenuList = _menuListCategories[UsersCategory.Visitor];
                            break;
                        case UsersCategory.Librarian:
                            CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageLibrarianHomepage];
                            MenuList = _menuListCategories[UsersCategory.Librarian];
                            break;
                        case UsersCategory.Chieflibrarian:
                            CurrentPageViewModel = PageViewModels[(int)PagesChoice.pageSuperUserHomepage];
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

        #endregion

        #region ManuItems Command

        private ICommand _menuItemsCommand;

        public ICommand MenuItemsCommand
        {
            get
            {
                return _menuItemsCommand ?? (_menuItemsCommand = new RelayCommand(x =>
                {

                    Trace.WriteLine("hello " + x.ToString());
                    ChangeViewModel(PageViewModels[(int)((PagesChoice)x)]);
                }));
            }
        }

        #endregion

        #region Search Command

        /// <summary>
        /// Command for the search button
        /// </summary>
        public ICommand btnSearch { get; set; }

        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        /// Bound to the search key textbox
        /// </summary>
        public string SearchKey { get; set; } = "";

        /// <summary>
        /// Array that contains all of the search filters
        /// </summary>
        public string[] CbxSearchFilters { get; set; }

        /// <summary>
        /// Filet type ID
        /// </summary>
        public int FilterTypID { get; set; }

        ///<summary>
        ///Get Multiple Bindings
        /// </summary>
   

        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<SearchItems> searchResultList;
        /// <summary>
        /// Contains the search result
        /// </summary>

        public ObservableCollection<SearchItems> SearchResultList
        {
            get => searchResultList;
            set
            {
                searchResultList = value;

                OnPropertyChanged(nameof(SearchResultList));
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

        #endregion

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private string _iDTextBox;
        private string _passwordTextBox;
        private string _accountCategory = "Bilfantast";
        private bool _isOpen = false;

        private Dictionary<UsersCategory, ObservableCollection<PagesChoice>> _menuListCategories = new Dictionary<UsersCategory, ObservableCollection<PagesChoice>>
        {
            {
                UsersCategory.Visitor, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageVisitorMyItems,
                    PagesChoice.pageVisitorSeminar
                }
            },
            {
                UsersCategory.Librarian, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageManageLibrarian,
                    PagesChoice.pageManageUsers,
                    PagesChoice.pageManageSeminar,
                    PagesChoice.pageReport
                }
            },
            {
                UsersCategory.Chieflibrarian, new ObservableCollection<PagesChoice>
                {
                    PagesChoice.pageManageUsers,
                    PagesChoice.pageManageLibrarian,
                    PagesChoice.pageManageSeminar,
                    PagesChoice.pageReport
                }
            }
        };
        private ObservableCollection<PagesChoice> _menuList = new ObservableCollection<PagesChoice> 
        {
            PagesChoice.pageAddLibrarian,
            PagesChoice.pageAddVisitor
        };

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

        public MainWindowViewModel()
        {
            CbxSearchFilters = new string[] { "Allting","Böker"};

            // Create the search Command
            btnSearch = new RelayCommand((o) => SearchItems(o));

            #region VAFAN E DE HÄR!?

            FilterTypID = 0;
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


            CurrentPageViewModel = PageViewModels[20];

            Mediator.Subscribe(PagesChoice.Page1, OnGoPage1Screen);
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


            #endregion
        }

        #region Command functions

        /// <summary>
        /// Search for objects
        /// </summary>
        /// <param name="o"></param>
        private void SearchItems(object o)
        {
            switch (FilterTypID)
            {

                case 0:
                    {

                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchItems(SearchKey));
                    }
                    break;
                case 1:
                    {
                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchBooks(SearchKey));
                    }
                    break;
                case 2:
                    {
                        //SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchEbooks(SearchKey));
                    }
                    break;
                case 3:
                    {

                       // SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchEbooks(SearchKey));
                    }
                    break;
            }
        }

        #endregion
    }
}
