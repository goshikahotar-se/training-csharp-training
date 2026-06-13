using csharp.Challenges.Shared;

namespace csharp.Challenges._04_customers_over_threshold;

public class CustomersOverThreshold
{
    public static void Run()
    {
        var listOfCustomerSaleLine = GetListOfCustomerSaleLine();
        var getGroupedCustomer = listOfCustomerSaleLine
            .GroupBy(x => x.CustomerId)
            .Select(computedTotalSpentPerCustomer => new CustomerSpendSummary
            {
                CustomerId = computedTotalSpentPerCustomer.Key,
                TotalSpent = computedTotalSpentPerCustomer.Sum(x => x.Line.Quantity * x.Line.UnitPrice)
            })
            .Where(x => x.TotalSpent > 100)
            .OrderByDescending(x => x.TotalSpent);
        
        Console.WriteLine("04-customers-over-threshold");
        
        foreach (var item in getGroupedCustomer)
        {
            Console.WriteLine(item.CustomerId);
            Console.WriteLine(item.TotalSpent);
        }
    }

    private static List<CustomerSaleLine> GetListOfCustomerSaleLine()
    {
        List<CustomerSaleLine> listOfCustomerSaleLine = new List<CustomerSaleLine>
        {
            new()
            {
                CustomerId = 1,
                Line = new SaleLine { ProductName = "Pencil", Quantity = 10, UnitPrice = 5 }
            },
            new()
            {
                CustomerId = 1,
                Line = new SaleLine { ProductName = "Eraser", Quantity = 30, UnitPrice = 2 }
            },
            new()
            {
                CustomerId = 2,
                Line = new SaleLine { ProductName = "ClearBag", Quantity = 5, UnitPrice = 20 }
            },
            new()
            {
                CustomerId = 2,
                Line = new SaleLine { ProductName = "Pencil", Quantity = 1, UnitPrice = 5 }
            },
            new()
            {
                CustomerId = 3,
                Line = new SaleLine { ProductName = "ClearBag", Quantity = 10, UnitPrice = 20 }
            },
            new()
            {
                CustomerId = 4,
                Line = new SaleLine { ProductName = "Eraser", Quantity = 2, UnitPrice = 2 }
            }
        };

        return listOfCustomerSaleLine;
    }
}
