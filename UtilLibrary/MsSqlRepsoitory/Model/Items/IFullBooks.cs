using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// The whole book, items and book table joined together
    /// </summary>
    public interface IFullBooks : IItems
    {
        string Author { get; set; }
        long ISBN { get; set; }
        string Category { get; set; }
        int Pages { get; set; }
        string Publisher { get; set; }
        public string SAB { get; set; }
        public string DDK { get; set; }
    }
}