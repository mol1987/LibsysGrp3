using System;
using System.Collections.Generic;
using System.Text;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ISearchMovies
    {
        string Title { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        string Director { get; set; }
        string Actors { get; set; }
        string Gener { get; set; }
    }
}
