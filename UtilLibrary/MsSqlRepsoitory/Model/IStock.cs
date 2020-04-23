namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IStock
    {
        int ItemsID { get; set; }
        int Qty { get; set; }
        int StockID { get; set; }
    }
}