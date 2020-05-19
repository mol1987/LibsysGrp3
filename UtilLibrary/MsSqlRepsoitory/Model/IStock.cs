namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IStock
    {
        int ItemsID { get; set; }
        int StockID { get; set; }
        bool Available { get; set; }
        string Reason { get; set; }
    }
}