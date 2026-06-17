namespace csharp.Challenges._06_retail_back_office_system.Domain;

public class StoreLineRequest
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}