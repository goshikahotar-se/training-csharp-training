using csharp.Challenges._05_cart_stock_validation.Application.Interfaces;
using csharp.Challenges._06_retail_back_office_system.Application.Interfaces;
using csharp.Challenges._06_retail_back_office_system.Application.Models;
using csharp.Challenges._06_retail_back_office_system.Application.Services;
using csharp.Challenges._06_retail_back_office_system.Domain;

namespace csharp.Challenges._06_retail_back_office_system;

public class OrderRequest
{
    public static void Run()
    {
        IPlaceOrder placeOrderRequestScenarioA = new PurchaseRequestService();
        IPlaceOrder placeOrderRequestScenarioB = new PurchaseRequestService();
        IPlaceOrder placeOrderRequestScenarioC = new PurchaseRequestService();
        IPlaceOrder placeOrderRequestScenarioD = new PurchaseRequestService();

        List<StoreLineRequest> requestPurchaseItemsScenarioA = new List<StoreLineRequest>
        {
            //scenario A
            new() {ProductId = 101, Quantity = 10},
            new() {ProductId = 102, Quantity = 5},
        };
        
        PlaceOrderRequest(placeOrderRequestScenarioA, requestPurchaseItemsScenarioA, 1);
        
        List<StoreLineRequest> requestPurchaseItemsScenarioB = new List<StoreLineRequest>
        {
            //scenario B
            new() {ProductId = 102, Quantity = 20},
        };
        
        PlaceOrderRequest(placeOrderRequestScenarioB, requestPurchaseItemsScenarioB, 1);
        
        List<StoreLineRequest> requestPurchaseItemsScenarioC = new List<StoreLineRequest>
        {
            //scenario C
            new() {ProductId = 103, Quantity = 1},
        };

        PlaceOrderRequest(placeOrderRequestScenarioC, requestPurchaseItemsScenarioC, 1);
        
        List<StoreLineRequest> requestPurchaseItemsScenarioD = new List<StoreLineRequest>
        {
            //scenario D
            new() { ProductId = 101, Quantity = 1 },
            new() { ProductId = 101, Quantity = 3 },
        };

        PlaceOrderRequest(placeOrderRequestScenarioD, requestPurchaseItemsScenarioD, 2);
    }

    private static void PlaceOrderRequest(IPlaceOrder placeOrderRequest, List<StoreLineRequest> requestPurchaseItems, int storeId)
    {
        var order = placeOrderRequest
            .PlaceOrder(storeId,
                99,
                requestPurchaseItems);

        PrintResult(order, placeOrderRequest.GetCartTotal());
    }

    private static void PrintResult(PurchaseStatus status, OrderReceipt receipt)
    {
        Console.WriteLine("Status: " + status.IsSuccess);
        Console.WriteLine("Order ID: " + receipt.OrderId);
        if (status.IsSuccess)
        {
            Console.WriteLine("Total: " + receipt.Total);
        }
        else
        {
            Console.WriteLine("Error: " + "Your purchase was declined");
        }
    }
}