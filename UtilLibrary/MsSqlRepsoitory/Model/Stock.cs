namespace UtilLibrary.MsSqlRepsoitory
{
    public class Stock : IStock
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public bool Available { get; set ; }
        public string Reason { get; set; }
    }
}
