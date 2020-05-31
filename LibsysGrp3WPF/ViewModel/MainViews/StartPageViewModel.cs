using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// The first page a visitor sees
    /// contains just a basic search window.
    /// </summary>
    public class StartPageViewModel : ManageBookViewModel, IPageViewModel
    {
        #region Private Properties
        private string _searchResultat;
        private ICommand _btnInfo;

        private bool _popupIsOpen = false;
        private string _txBInfo;

        #endregion
        #region Public Properties

        ///<summary>
        ///Bound Button Search
        /// </summary>
        public RelayCommand btnSearch { get; set; }


        /// <summary>
        /// Bound to the search key textbox
        /// </summary>
        public string SearchKey { get; set; } = "";

        /// <summary>
        /// Array that contains all of the search filters
        /// </summary>
        public string[] CbxSearchFilters { get; set; }

        /// <summary>
        /// FiltertypeID
        /// </summary>
        public int FilterTypID { get; set; } = 1;

        /// <summary>
        /// Contains the search result
        /// </summary>
        private ObservableCollection<SearchItems> searchResultList;
        /// <summary>
        /// Contains the search result
        /// </summary>
        /// 
      

        public ObservableCollection<SearchItems> SearchResultList
        {
            get => searchResultList;
            set
            {
                searchResultList = value;

                OnPropertyChanged(nameof(SearchResultList));
            }
        }

        public bool PopupIsOpen
        {
            get
            {
                return _popupIsOpen;
            }
            set
            {
                _popupIsOpen = value;
                OnPropertyChanged(nameof(PopupIsOpen));
            }
        }

        public string TxBInfo
        {
            get
            {
                return _txBInfo;
            }
            set
            {
                _txBInfo = value;
                OnPropertyChanged(nameof(TxBInfo));
            }
        }




        public ICommand BtnInfo
        {
            get
            {
                return _btnInfo ?? (_btnInfo = new RelayCommand(x =>
                {
                    PopupIsOpen = true;
                }));
            }
        }

        /// <summary>
        /// Message that comes after search
        /// </summary>
        public string SearchResultatText
        {
            get
            {
                return _searchResultat;
            }
            set
            {
                _searchResultat = value;
                OnPropertyChanged(nameof(SearchResultatText));
            }
        }


        #endregion

        #region Methods
        public void run()
        {
            CbxSearchFilters = new string[] { "Allting", "Böcker", "Online Böcker", "Filmer" };
            TxBInfo = "För att låna böckerna vänligen logga in.\n" +
                "Om du inte har konto vänligen besöka vår reception och bibliotekariet skapar en konto åt dig.\n" +
                "Om du har glömt din inloggningsuppgifter vänligen kontakta bibliotekspersonal.";
            // Create the search Command
            btnSearch = new RelayCommand((o) =>
            {
                SearchItems(o);
                if (o == null)
                {
                    SearchResultatText = "Hittade inga produkter, vänligen sök igen.";
                }
            });
        }
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
                        BooksList = FullBooksModel.ConvertToObservableCollection((new LibsysRepo()).SearchAllItemBook(SearchKey));
                    }
                    break;
                case 2:
                    {
                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchEbooks(SearchKey));
                    }
                    break;
                case 3:
                    {

                        SearchResultList = new ObservableCollection<SearchItems>((new LibsysRepo()).SearchMovies(SearchKey));
                    }
                    break;
            }
        }
        #endregion
    }
}
