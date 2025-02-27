using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// API response model for GetSaleItem operation
/// </summary>
public class GetSaleItemResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// SaleId
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// ProductId
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Quantity    
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// UnitPrice    
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Discount    
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// TotalAmount    
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; set; } = false;

    /// <summary>
    /// Product    
    /// </summary>
    public GetProductResponse Product { get; set; } = new();
}
