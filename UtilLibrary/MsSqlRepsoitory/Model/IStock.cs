namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IStock
    {
        int StockID { get; set; }
        int ItemsID { get; set; }
        bool Available { get; set; }
       
        string Reason { get; set; }
    }
}