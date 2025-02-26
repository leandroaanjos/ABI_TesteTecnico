using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Represents a request to create a new saleItem in the system.
/// </summary>
public class CreateSaleItemRequest
{
    /// <summary>
    /// Quantity    
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// UnitPrice    
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; set; } = false;

    /// <summary>
    /// ProductId
    /// </summary>
    public Guid ProductId { get; set; } = new();
}