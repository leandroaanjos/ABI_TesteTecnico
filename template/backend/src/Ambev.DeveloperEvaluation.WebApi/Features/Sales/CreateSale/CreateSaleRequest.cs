using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// SaleNumber    
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// SaleDate
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Customer
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Branch
    /// </summary>
    public string Branch { get; set; } = string.Empty;
    
    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; set; } = false;

    /// <summary>
    /// Items
    /// </summary>
    public ICollection<CreateSaleItemRequest> Items { get; set; } = [];
}