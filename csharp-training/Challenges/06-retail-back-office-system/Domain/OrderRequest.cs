namespace csharp.Challenges._06_retail_back_office_system.Domain;

public class OrderRequest
{
    public required int StoreId { get; set; }
    public required int CustomerId { get; set; }
    public required StoreLineRequest Lines { get; set; }
}