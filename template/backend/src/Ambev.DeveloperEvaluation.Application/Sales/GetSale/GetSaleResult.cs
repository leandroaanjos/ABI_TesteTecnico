using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
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
    public decimal TotalAmount { get; set; }

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
    public List<GetSaleItemResult> Items { get; set; } = [];
}
