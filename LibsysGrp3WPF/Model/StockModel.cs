using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UtilLibrary.MsSqlRepsoitory
{
    public class StockModel : IStock
    {
        public int StockID { get; set; }
        public int ItemsID { get; set; }
        public bool Available { get ; set ; }
        public string Reason { get; set; }



        public static ObservableCollection<StockModel> ConvertToObservableCollection(IEnumerable<IStock> inData)
        {
            var stockList = new ObservableCollection<StockModel>();
            foreach (var item in inData)
            {
                stockList.Add(new StockModel()
                {
                    StockID = item.StockID,
                    ItemsID = item.ItemsID,
                    Available = item.Available,
                    Reason = item.Reason,
                }
                );
            }
            return stockList;
        }
    }
}
