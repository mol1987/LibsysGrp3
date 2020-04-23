namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IFullMovies
    {
        string Actors { get; set; }
        string Director { get; set; }
        int Duration { get; set; }
        string Genre { get; set; }
        int MoviesID { get; set; }
    }
}