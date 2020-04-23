namespace UtilLibrary.MsSqlRepsoitory
{
    public class Items : IItems
    {
        public int ItemsID { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
