using csharp.Challenges._05_cart_stock_validation.Application.Interfaces;
using csharp.Challenges._05_cart_stock_validation.Application.Services;
using csharp.Challenges._05_cart_stock_validation.Models;

namespace csharp.Challenges._05_cart_stock_validation;

public class CartStockValidation
{
    
    
    public static void Run()
    {
        IOrderService orderService = new OrderService();
        PrintResult("10 Pencil", orderService.AddToCart(101, 10), orderService.GetCartTotal());
        PrintResult("5 ClearBag",  orderService.AddToCart(102, 5), orderService.GetCartTotal());
    }

    private static void PrintResult(string label, CustomerCartStatus result, double cartTotal)
    {
        Console.WriteLine(label);
        Console.WriteLine(result.Status);
        Console.WriteLine(cartTotal);
        if (result.Exception != null)
        {
            Console.WriteLine(result.Exception);
        }
        Console.WriteLine();
    }
}