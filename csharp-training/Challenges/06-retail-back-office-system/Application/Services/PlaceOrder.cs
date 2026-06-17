using csharp.Challenges._06_retail_back_office_system.Application.Helper;
using csharp.Challenges._06_retail_back_office_system.Application.Interfaces;
using csharp.Challenges._06_retail_back_office_system.Application.Models;
using csharp.Challenges._06_retail_back_office_system.Domain;

namespace csharp.Challenges._06_retail_back_office_system.Application.Services;

public class PurchaseRequestService : IPlaceOrder
{
    private List<StockItem> _storeProductList = new()
    {
        new StockItem { StoreId = 1, ProductId = 101, QuantityAvailable = 100 },
        new StockItem { StoreId = 1, ProductId = 102, QuantityAvailable = 15 },
        new StockItem { StoreId = 1, ProductId = 103, QuantityAvailable = 0 },
        new StockItem { StoreId = 2, ProductId = 101, QuantityAvailable = 3 },
        new StockItem { StoreId = 2, ProductId = 102, QuantityAvailable = 50 },
        new StockItem { StoreId = 2, ProductId = 103, QuantityAvailable = 10 }
    };

    private readonly List<Product> _productDetails = new()
    {
        new Product { ProductId = 101, Name = "Pencil", UnitPrice = 5 },
        new Product { ProductId = 102, Name = "Clearbag", UnitPrice = 20 },
        new Product { ProductId = 103, Name = "Eraser", UnitPrice = 2 }
    };

    private Dictionary<int, int> _purchasedItemsDictionary = new();

    private double _totalAmountOfPurchasedProducts;

    private bool _purchaseStatus = true;
    
    private int _quantityOfPurchasedProducts = 0;
    private readonly PrintPurchaseDetails _printPurchaseDetails;

    public PurchaseRequestService()
    {
        _printPurchaseDetails = new PrintPurchaseDetails();
    }

    public PurchaseStatus PlaceOrder(int storeId, int customerId, List<StoreLineRequest> itemsSelectedByCustomer)
    {
        Console.WriteLine("BEFORE ORDER: ");
        _printPurchaseDetails.PrintStockOfSelectedItems(storeId, itemsSelectedByCustomer, _storeProductList);
        
        var groupedByProductId = itemsSelectedByCustomer
            .GroupBy(x => x.ProductId)
            .Select(bucket => new
            {
                ProductId = bucket.Key,
                Quantity = bucket.Sum(x => x.Quantity)
            })
            .ToList();
        
        foreach (var product in itemsSelectedByCustomer)
        {
            if (!_purchasedItemsDictionary.ContainsKey(product.ProductId))
            {
                int quantityInStock = _storeProductList
                    .FirstOrDefault(x => x.ProductId == product.ProductId && x.StoreId == storeId)!.QuantityAvailable;
                
                var compareGroupedResultWithQuantityInStock = groupedByProductId
                                                                                    .FirstOrDefault(x => x.ProductId == product.ProductId);

                if ( (compareGroupedResultWithQuantityInStock?.Quantity ?? 0) > quantityInStock)
                {
                    return new PurchaseStatus{ IsSuccess = false, 
                                               ErrorMessage = $"Product {product.ProductId} is out of stock." };
                }
            }
        }

        foreach (var product in itemsSelectedByCustomer)
        {
            if (_purchasedItemsDictionary.ContainsKey(product.ProductId))
            {
                _purchasedItemsDictionary[product.ProductId] += product.Quantity;
            }
            else
            {
                _purchasedItemsDictionary.Add(product.ProductId, product.Quantity);
            }
        }

        foreach (var product in groupedByProductId)
        {
            var stockItem = _storeProductList.FirstOrDefault(x => x.ProductId == product.ProductId && x.StoreId == storeId);
            if (stockItem != null)
            {
                stockItem.QuantityAvailable -= product.Quantity;
            }
        }
        Console.WriteLine("AFTER ORDER: ");
        _printPurchaseDetails.PrintStockOfSelectedItems(storeId, itemsSelectedByCustomer, _storeProductList);
        
        return new PurchaseStatus{ IsSuccess = true };
    }

    public OrderReceipt GetCartTotal()
    {
        foreach (var purchasedItem in _purchasedItemsDictionary)
        {
            if (_purchasedItemsDictionary.Count > 0)
            {
                var productId = purchasedItem.Key;
                double unitPrice = _productDetails.Where(x => x.ProductId == productId).Select(x => x.UnitPrice).DefaultIfEmpty(0).Max();
                _totalAmountOfPurchasedProducts += (unitPrice * purchasedItem.Value);
            }
        }

        return new OrderReceipt { OrderId = new Random().Next(100),Total = _totalAmountOfPurchasedProducts };
    }
}