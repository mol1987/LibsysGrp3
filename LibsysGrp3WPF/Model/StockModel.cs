namespace UtilLibrary.MsSqlRepsoitory
{
    public class StockModel : IStock
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public int Qty { get; set; }
    }
}
