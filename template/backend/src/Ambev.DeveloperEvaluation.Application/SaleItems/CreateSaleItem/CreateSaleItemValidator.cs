using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for saleItem creation command.
/// </summary>
public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Quantity: Required, must be between 1 and 20 units
    /// - UnitPrice: Required, must be greater or equal to zero
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
        RuleFor(x => x.Quantity).Must(x => x >= 1 && x <= 20);
        RuleFor(x => x.UnitPrice).Must(x => x >= 0);
    }
}