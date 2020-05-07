using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using LibsysGrp3WPF.Views;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class MainWindowViewModel : BaseViewModel
    {
        
        private ICommand _btnSignIn;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private string _iDTextBox;
        private string _passwordTextBox;
        private string _accountCategory = "Bilfantast";
        private bool _isOpen = false;

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
                    IsOpen = false;
                }));
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


            CurrentPageViewModel = PageViewModels[0];

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
        }
        #endregion
    }
}
