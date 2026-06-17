using csharp.Challenges._06_retail_back_office_system.Domain;

namespace csharp.Challenges._06_retail_back_office_system.Application.Helper;

public class PrintPurchaseDetails
{
    public void PrintStockOfSelectedItems(int storeId, List<StoreLineRequest> itemsSelectedByCustomer, List<StockItem> storeProductList)
    {
        foreach (var item in itemsSelectedByCustomer)
        {
            var productId = item.ProductId;
            var stockItem =
                storeProductList.FirstOrDefault(x => x.ProductId == productId && x.StoreId == storeId);

            int quantityInStock = stockItem != null ? stockItem.QuantityAvailable : 0;
            
            Console.WriteLine("Store : " + storeId + ", Product: " +productId + ", QuantityInStock: " + quantityInStock);
        }
    }
}