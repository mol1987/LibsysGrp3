using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageLibrariansViewModel : BaseViewModel, IPageViewModel
    {
        #region Private properties

        private ICommand _btnAddLibrarian;
        private ICommand _btnDeleteLibrarian;
        private ICommand _btnEditLibrarian;

        #endregion

        #region Public properties
        public ICommand btnAddLibrarian
        {
            get
            {
                return _btnAddLibrarian ?? (_btnAddLibrarian = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageAddLibrarian);
                }));
            }
        }

        public ICommand btnDeleteLibrarian
        {
            get
            {
                return _btnDeleteLibrarian ?? (_btnDeleteLibrarian = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageDeleteLibrarian);
                }));
            }
        }

        public ICommand btnEditLibrarian
        {
            get
            {
                return _btnEditLibrarian ?? (_btnEditLibrarian = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageEditLibrarian);
                }));
            }
        }

        #endregion

    }
}
