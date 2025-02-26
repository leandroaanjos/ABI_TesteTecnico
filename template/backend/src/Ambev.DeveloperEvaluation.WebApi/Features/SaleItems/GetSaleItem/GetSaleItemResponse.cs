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
    public Guid SaleId { get; private set; }

    /// <summary>
    /// ProductId
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Product    
    /// </summary>
    public GetProductResponse Product { get; private set; } = new();

    /// <summary>
    /// Quantity    
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// UnitPrice    
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Discount    
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// TotalAmount    
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; private set; } = false;
}
