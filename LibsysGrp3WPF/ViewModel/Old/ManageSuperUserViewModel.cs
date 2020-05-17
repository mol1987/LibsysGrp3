using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageSuperuserViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties

        private ICommand _btnAddSuperuser;
        private ICommand _btnDeleteSuperuser;
        private ICommand _btnEditSuperuser;
        private ICommand _btnLogout;
        private ICommand _btnGoBack;

        private IPageViewModel _currentContent;

        #endregion

        #region Public properties
        public IPageViewModel CurrentContent
        {
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

        public ICommand btnAddSuperuser
        {
            get
            {
                return _btnAddSuperuser ?? (_btnAddSuperuser = new RelayCommand(x =>
                {
                    CurrentContent = new AddSuperuserViewModel();
                }));
            }
        }

        public ICommand btnDeleteSuperuser
        {
            get
            {
                return _btnDeleteSuperuser ?? (_btnDeleteSuperuser = new RelayCommand(x =>
                {
                    CurrentContent = new DeleteSuperuserViewModel();
                }));
            }
        }

        public ICommand btnEditSuperuser
        {
            get
            {
                return _btnEditSuperuser ?? (_btnEditSuperuser = new RelayCommand(x =>
                {
                    CurrentContent = new EditSuperuserViewModel();
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
        public ManageSuperuserViewModel()
        {
            CurrentContent = null;
        }
        #endregion

        public void run()
        {
        }
    }
}
