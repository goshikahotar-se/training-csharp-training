using csharp.Challenges._06_retail_back_office_system.Application.Models;
using csharp.Challenges._06_retail_back_office_system.Domain;

namespace csharp.Challenges._06_retail_back_office_system.Application.Interfaces;

public interface IPlaceOrder
{
    PurchaseStatus PlaceOrder(int storeId, int customerId, List<StoreLineRequest> itemsSelectedByCustomer);
    OrderReceipt GetCartTotal();
}