using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface ISeminars
    {
        string Author { get; set; }
        DateTime Date { get; set; }
        int Duration { get; set; }
        int SeminarsID { get; set; }
    }
}