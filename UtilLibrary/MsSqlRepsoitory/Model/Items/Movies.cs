﻿namespace UtilLibrary.MsSqlRepsoitory
{
    public class Movies : IMovies
    {
        public int MoviesID { get; set; }
        public int ItemsID { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
    }
}
