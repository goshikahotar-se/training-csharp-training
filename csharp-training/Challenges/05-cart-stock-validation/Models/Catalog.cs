namespace csharp.Challenges._05_cart_stock_validation.Models;

public class Catalog
{
    public required int ProductId { get; set; }
    public required string Name { get; set; }
    public required int UnitPrice { get; set; }
    public required int Stock { get; set; }
}