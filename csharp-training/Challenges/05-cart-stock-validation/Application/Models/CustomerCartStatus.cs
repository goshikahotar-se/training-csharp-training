namespace csharp.Challenges._05_cart_stock_validation.Models;

public class CustomerCartStatus
{
    public required string Status { get; set; }
    public string? Exception { get; set; }
}