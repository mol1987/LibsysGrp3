using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageLibrariansViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties

        private ICommand _btnAddLibrarian;
        private ICommand _btnDeleteLibrarian;
        private ICommand _btnEditLibrarian;
        private ICommand _btnLogout;
        private ICommand _btnGoBack;

        private IPageViewModel _currentContent;

        #endregion

        #region Public properties
        public IPageViewModel CurrentContent { 
            get 
            {
                return _currentContent;
            } 
            set 
            {
                _currentContent = value;
                OnPropertyChanged(nameof(CurrentContent));
            } 
        }

        public ICommand btnAddLibrarian
        {
            get
            {
                return _btnAddLibrarian ?? (_btnAddLibrarian = new RelayCommand(x =>
                {
                    CurrentContent = new AddLibrarianViewModel();
                }));
            }
        }

        public ICommand btnDeleteLibrarian
        {
            get
            {
                return _btnDeleteLibrarian ?? (_btnDeleteLibrarian = new RelayCommand(x =>
                {
                    CurrentContent = new DeleteLibrarianViewModel();
                }));
            }
        }

        public ICommand btnEditLibrarian
        {
            get
            {
                return _btnEditLibrarian ?? (_btnEditLibrarian = new RelayCommand(x =>
                {
                    CurrentContent = new EditLibrarianViewModel();
                }));
            }
        }

        public ICommand btnLogout
        {
            get
            {
                return _btnLogout ?? (_btnLogout = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.Page1, "");
                }));
            }
        }

        public ICommand btnGoBack
        {
            get
            {
                return _btnGoBack ?? (_btnGoBack = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageSuperUserHomepage, "");
                }));
            }
        }


        #endregion

        #region Constructor
        public ManageLibrariansViewModel()
        {
            CurrentContent = null;
        }
        #endregion
    }
}
