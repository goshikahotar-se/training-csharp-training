using csharp.Challenges._05_cart_stock_validation.Application.Interfaces;
using csharp.Challenges._05_cart_stock_validation.Models;

namespace csharp.Challenges._05_cart_stock_validation.Application.Services;

public class OrderService : IOrderService
{
    private static readonly List<Catalog> ListOfCatalogItems = new()
    {
        new()
        {
            ProductId = 101, Name = "Pencil", UnitPrice = 5, Stock = 100
        },
        new()
        {
            ProductId = 102, Name = "ClearBag", UnitPrice = 20, Stock = 15
        },
        new()
        {
            ProductId = 103, Name = "Eraser", UnitPrice = 2, Stock = 0
        }
    };

    private static readonly Dictionary<int, Cart> DictionaryOfSelectedProducts = new();
    
    public CustomerCartStatus AddToCart(int productId, int quantity)
    {
        var itemsInCatalog = ListOfCatalogItems;
        var productIsPresentInCatalog = IsProductFoundInCatalog(productId, itemsInCatalog);

        if (QuantityInsertedIsInvalid(quantity))
            return new CustomerCartStatus { Status = "Failure", Exception = "Must specify valid quantity of product." };

        if (!productIsPresentInCatalog.Any())
        {
            return new CustomerCartStatus { Status = "Failure", Exception = "Product not found in catalog."};
        }

        if (quantity > AvailableQuantityInStock(productId, itemsInCatalog))
        {
            return new CustomerCartStatus
            {
                Status = "Failure",
                Exception = "We do not have this number of product in stock."
            };
        }

        if (DictionaryOfSelectedProducts.ContainsKey(productId))
        {
            if ( quantity > RemainingQuantityOfProductInStock(productId, itemsInCatalog) )
                return new CustomerCartStatus
                {
                    Status = "Failure",
                    Exception = "This quantity of the product is now out of stock"
                };
        }
        
        UpdateCart(productId, quantity, (itemsInCatalog.FirstOrDefault(p => p.ProductId == productId)!.UnitPrice));
        
        return new CustomerCartStatus
        {
            Status = "Success"
        };
    }

    public double GetCartTotal()
    {
        double total = 0;
        
        foreach (var (key, value) in DictionaryOfSelectedProducts)
        {
            total += value.Quantity * value.UnitPrice;
        }

        return total;
    }

    private static int RemainingQuantityOfProductInStock(int productId, List<Catalog> itemsInCatalog)
    {
        return (((itemsInCatalog.FirstOrDefault(p => p.ProductId == productId)!).Stock) -
                DictionaryOfSelectedProducts[productId].Quantity);
    }

    private static int AvailableQuantityInStock(int productId, List<Catalog> itemsInCatalog)
    {
        return ((itemsInCatalog.FirstOrDefault(p => p.ProductId == productId)!).Stock);
    }

    private static bool QuantityInsertedIsInvalid(int quantity)
    {
        return quantity == 0 || quantity < 0;
    }

    private static IEnumerable<Catalog> IsProductFoundInCatalog(int productId, List<Catalog> itemsInCatalog)
    {
        var productIsPresent = itemsInCatalog.Where(p => p.ProductId == productId);
        return productIsPresent;
    }

    private static void UpdateCart(int productId, int quantity, double price)
    {
        if (DictionaryOfSelectedProducts.ContainsKey(productId))
        {
            if (DictionaryOfSelectedProducts.TryGetValue(productId, out Cart? cart))
                cart.Quantity +=  quantity;
        }
        else
        {
            DictionaryOfSelectedProducts.Add(productId, new Cart { Quantity = quantity, UnitPrice = price });
        }
    }

    private static void PrintResult(string label, CustomerCartStatus result)
    {
        Console.WriteLine(label);
        Console.WriteLine(result.Status);
        if (result.Exception != null)
        {
            Console.WriteLine(result.Exception);
        }
        Console.WriteLine();
    }
}