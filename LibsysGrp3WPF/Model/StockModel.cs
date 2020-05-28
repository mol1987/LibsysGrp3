namespace UtilLibrary.MsSqlRepsoitory
{
    public class StockModel : IStock
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public int Qty { get; set; }
        public bool Available { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Reason { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
