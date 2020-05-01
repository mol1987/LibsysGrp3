


using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageVisitorsViewModel : BaseViewModel, IPageViewModel
    {

        #region private properties

        private ICommand _btnAddVisitor;
        private ICommand _btnDeleteVisitor;
        private ICommand _btnEditVisitor;

        #endregion

        #region public properties

        public ICommand btnAddVisitor
        {
            get
            {
                return _btnAddVisitor ?? (_btnAddVisitor = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageAddVisitor);
                }));
            }
        }

        public ICommand btnDeleteVisitor
        {
            get
            {
                return _btnDeleteVisitor ?? (_btnDeleteVisitor = new RelayCommand(x =>
                {
                   Mediator.Notify(PagesChoice.pageDeleteVisitor);
                }));
            }
        }

        public ICommand btnEditVisitor
        {
            get
            {
                return _btnEditVisitor ?? (_btnEditVisitor = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageEditVisitor);
                }));
            }
        }

        #endregion

    }

}

