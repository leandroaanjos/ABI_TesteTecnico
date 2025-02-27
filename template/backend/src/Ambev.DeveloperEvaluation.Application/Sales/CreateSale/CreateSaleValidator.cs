using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - SaleNumber: Required, must be between 10 and 50 characters
    /// - SaleDate: Required
    /// - Customer: Required, must be between 3 and 50 characters
    /// - Branch: Required, must be between 3 and 50 characters
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.SaleNumber).NotEmpty().Length(10, 50);
        RuleFor(x => x.SaleDate).Must(x => x != DateTime.MinValue);
        RuleFor(x => x.Customer).NotEmpty().Length(3, 50);
        RuleFor(x => x.Branch).NotEmpty().Length(3, 50);
    }
}