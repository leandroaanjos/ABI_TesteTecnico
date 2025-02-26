using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a Sale in the system
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
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
    public ICollection<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// IsCancelled    
    /// </summary>
    public bool IsCancelled { get; private set; } = false;

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Add a SaleItem
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void AddItem(Product product, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");

        Items.Add(new SaleItem(product, quantity, unitPrice));
        UpdateTotalAmount();
    }

    /// <summary>
    /// Update TotalAmount property
    /// </summary>
    private void UpdateTotalAmount()
    {
        TotalAmount = Items.Sum(i => !i.IsCancelled ? i.TotalAmount : 0);
    }

    public void Cancel()
    {
        IsCancelled = true;        
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
    /// <list type="bullet">Title length</list>
    /// <list type="bullet">Description length</list>
    /// <list type="bullet">Category length</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}