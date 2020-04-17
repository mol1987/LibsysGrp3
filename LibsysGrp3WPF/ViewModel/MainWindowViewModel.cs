using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibsysGrp3WPF.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

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

        private void OnGoPage1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoPage2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
      

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new Page1ViewModel());
            PageViewModels.Add(new Page2ViewModel());

            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe(PagesChoice.Page1, OnGoPage1Screen);
            Mediator.Subscribe(PagesChoice.Page2, OnGoPage2Screen);
        }
    }
}
