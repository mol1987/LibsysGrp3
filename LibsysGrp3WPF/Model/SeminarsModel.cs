using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class SeminarsModel : ISeminars
    {
        public int SeminarsID { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
    }
}
