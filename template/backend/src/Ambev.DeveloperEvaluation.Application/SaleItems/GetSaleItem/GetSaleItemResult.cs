using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Response model for GetSaleItem operation
/// </summary>
public class GetSaleItemResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product    
    /// </summary>
    public GetProductResult Product { get; private set; } = new();

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
