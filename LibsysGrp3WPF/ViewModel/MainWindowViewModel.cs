using System.Collections.Generic;
using System.Linq;

namespace LibsysGrp3WPF
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels //vad händer om det är inte null
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
            PageViewModels.Add(new ManageSuperUserViewModel());
            PageViewModels.Add(new ReportsViewModel());
            PageViewModels.Add(new LibrariansHomePageViewModel());
            PageViewModels.Add(new ManageBookPageViewModel());
            PageViewModels.Add(new ManageEbookPageViewModel());
            PageViewModels.Add(new ManageSeminarPageViewModel());


            CurrentPageViewModel = PageViewModels[7];

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
        }
        #endregion
    }
}
