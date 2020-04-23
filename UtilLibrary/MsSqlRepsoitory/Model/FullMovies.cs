using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class FullMovies : Items
    {
        public int MoviesID { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
    }
}
