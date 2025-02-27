using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a SaleItem in the system
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
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
    public decimal Discount { get; private set; }

    /// <summary>
    /// TotalAmount    
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; set; } = false;

    /// <summary>
    /// Sale
    /// </summary>
    public Sale Sale { get; set; } = new();

    /// <summary>
    /// Product    
    /// </summary>
    public Product Product { get; set; } = new();

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    
    public SaleItem()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public SaleItem(Product product, int quantity, decimal unitPrice)
    {
        CreatedAt = DateTime.UtcNow;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        CalculateTotalAmount();
    }

    public decimal CalculateTotalAmount()
    {
        ApplyDiscount();
        TotalAmount = (UnitPrice * Quantity) - Discount;
        return TotalAmount;
    }

    private void ApplyDiscount()
    {
        Discount = Quantity switch
        {
            >= 4 and < 10 => UnitPrice * Quantity * 0.10m,
            >= 10 and <= 20 => UnitPrice * Quantity * 0.20m,
            _ => 0,
        };
    }

    public void Cancel()
    {
        IsCancelled = true;
        // TODO notificar Sales class para chamar o metodo Sale.UpdateTotalAmount, pois o item foi cancelado
        // LogEvent("SaleItemCancelled", this);
    }

    /// <summary>
    /// Performs validation of the user entity using the UserValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Quantity</list>    
    /// <list type="bullet">UnitPrice</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}