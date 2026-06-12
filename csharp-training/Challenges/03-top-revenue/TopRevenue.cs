namespace csharp.Challenges._03_top_revenue;

public class Product
{
    public static void Run()
    {
        List<SaleLine> listOfItems = new List<SaleLine>
        {
            new() { ProductId = 101, ProductName = "Pencil", Quantity = 100, UnitPrice = 5, StoreId = 1 },
            new() { ProductId = 102, ProductName = "ClearBag", Quantity = 10, UnitPrice = 20, StoreId = 1 },
            new() { ProductId = 103, ProductName = "Eraser", Quantity = 100, UnitPrice = 2, StoreId = 1 },
            new() { ProductId = 102, ProductName = "ClearBag", Quantity = 30, UnitPrice = 20, StoreId = 1 }
        };


        GetTop3ProductNamesByRevenue(listOfItems);
    }

    private static void GetTop3ProductNamesByRevenue(List<SaleLine> listOfItems)
    {
        var groupedProducts = listOfItems
            .GroupBy(p => p.ProductName)
            .Select(computedAmountPerProductId => new GroupedProductResult
            {
                ProductName = computedAmountPerProductId.Key,
                TotalPrice = computedAmountPerProductId.Sum(p => p.Quantity * p.UnitPrice)
            })
            .OrderByDescending(computedAmountPerProductId => computedAmountPerProductId.TotalPrice)
            .Take(3);

        foreach (var item in groupedProducts)
        {
            Console.WriteLine("ProductName: " + item.ProductName);
            Console.WriteLine("Total Price: " + item.TotalPrice);
        }
    }
}