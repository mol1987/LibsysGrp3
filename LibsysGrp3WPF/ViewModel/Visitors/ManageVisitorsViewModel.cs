


using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageVisitorsViewModel : BaseViewModel, IPageViewModel
    {

        #region private properties

        private ICommand _btnAddVisitor;
        private ICommand _btnDeleteVisitor;
        private ICommand _btnEditVisitor;

        private IPageViewModel _currentContent;

        #endregion

        #region public properties

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

        public ICommand btnAddVisitor
        {
            get
            {
                return _btnAddVisitor ?? (_btnAddVisitor = new RelayCommand(x =>
                {
                    CurrentContent = new AddVisitorViewModel();
                }));
            }
        }

        public ICommand btnDeleteVisitor
        {
            get
            {
                return _btnDeleteVisitor ?? (_btnDeleteVisitor = new RelayCommand(x =>
                {
                    CurrentContent = new DeleteVisitorViewModel();
                }));
            }
        }

        public ICommand btnEditVisitor
        {
            get
            {
                return _btnEditVisitor ?? (_btnEditVisitor = new RelayCommand(x =>
                {
                    CurrentContent = new EditVisitorViewModel();
                }));
            }
        }

        #endregion

        #region Constructor

        public ManageVisitorsViewModel()
        {
            CurrentContent = null;
        }

        #endregion

    }

}

