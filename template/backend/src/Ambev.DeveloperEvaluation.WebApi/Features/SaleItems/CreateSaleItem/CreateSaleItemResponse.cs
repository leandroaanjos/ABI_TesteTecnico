using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// API response model for CreateSaleItem operation
/// </summary>
public class CreateSaleItemResponse
{
    /// <summary>
    /// The unique identifier of the created saleItem
    /// </summary>
    public Guid Id { get; set; }

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
    /// Product
    /// </summary>
    public CreateProductResponse Product { get; set; } = new();
}
