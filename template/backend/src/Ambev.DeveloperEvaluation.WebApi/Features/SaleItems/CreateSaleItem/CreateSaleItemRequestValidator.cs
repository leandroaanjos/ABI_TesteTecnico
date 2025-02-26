using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemRequest that defines validation rules for saleItem creation.
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity: Required, must be between 1 and 20 units
    /// - UnitPrice: Required    
    /// </remarks>
    public CreateSaleItemRequestValidator()
    {
        RuleFor(x => x.Quantity).Must(x => x >= 1 && x <= 20);
        RuleFor(x => x.UnitPrice).Must(x => x >= 0);
    }
}