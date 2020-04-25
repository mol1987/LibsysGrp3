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

        #region Page assignmen to enums
        private void OnGoPage1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoPage2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void OnGoPageManageVisitor(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void OnGoPageManageLibrarian(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void OnGoSuperuserHomePage(object obj)
        {
            ChangeViewModel(PageViewModels[6]);
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

            CurrentPageViewModel = PageViewModels[2];

            Mediator.Subscribe(PagesChoice.Page1, OnGoPage1Screen);
            Mediator.Subscribe(PagesChoice.Page2, OnGoPage2Screen);
            Mediator.Subscribe(PagesChoice.pageManageVisitor, OnGoPageManageVisitor);
            Mediator.Subscribe(PagesChoice.pageManageLibrarian, OnGoPageManageLibrarian);
            Mediator.Subscribe(PagesChoice.pageSuperUserHomepage, OnGoSuperuserHomePage);
        }
        #endregion
    }
}
