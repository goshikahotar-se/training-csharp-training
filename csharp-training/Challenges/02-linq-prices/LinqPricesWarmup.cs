namespace csharp.Challenges._02_linq_prices;

public class LinqPricesWarmup
{
    public static void Run()
    {
        List<int> prices = new() { 10, 25, 3, 40, 7 };
    
        var result = prices
            .Where(p => p > 5)
            .Select(p => p*2)
            .OrderBy(p => p)
            .ToList();
        Console.WriteLine("02-linq-prices: ");
        Console.WriteLine(string.Join(",", result));
    }
}