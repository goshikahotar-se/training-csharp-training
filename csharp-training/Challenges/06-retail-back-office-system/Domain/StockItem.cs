namespace csharp.Challenges._06_retail_back_office_system.Domain;

public class StockItem
{
    public required int StoreId { get; set; }
    public required int ProductId { get; set; }
    public required int QuantityAvailable { get; set; }
}