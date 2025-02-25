using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Title    
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Price
    /// </summary>
    // public decimal Price { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Image
    /// </summary>
    public string Image { get; set; } = string.Empty;
}