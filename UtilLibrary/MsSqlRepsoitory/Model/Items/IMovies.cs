namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IMovies
    {
        string Actors { get; set; }
        string Director { get; set; }
        int Duration { get; set; }
        string Genre { get; set; }
        int ItemsID { get; set; }
        int MoviesID { get; set; }
    }
}