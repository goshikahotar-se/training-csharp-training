namespace csharp.Challenges._06_retail_back_office_system.Domain;

public class Product
{
    public required int ProductId { get; set; }
    public required string Name { get; set; }
    public required double UnitPrice { get; set; }
}