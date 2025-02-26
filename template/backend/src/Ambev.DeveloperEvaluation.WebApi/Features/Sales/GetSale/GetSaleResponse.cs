using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

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
    /// TotalAmount    
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Branch
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Items
    /// </summary>
    public List<GetSaleItemResponse> Items { get; set; } = [];

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; private set; } = false;
}
