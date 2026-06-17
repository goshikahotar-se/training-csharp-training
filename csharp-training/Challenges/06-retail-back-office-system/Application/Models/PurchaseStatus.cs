namespace csharp.Challenges._06_retail_back_office_system.Application.Models;

public class PurchaseStatus
{
    public required bool IsSuccess { get; set; }
    public double? Total { get; set; }
    public string? ErrorMessage { get; set; }
    
}