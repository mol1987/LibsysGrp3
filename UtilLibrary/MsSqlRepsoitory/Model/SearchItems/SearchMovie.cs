using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class SearchMovie : ISearchMovies
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Gener { get; set; }
    }
}
