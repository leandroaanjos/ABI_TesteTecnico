using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Required, must be between 10 and 50 characters
    /// - SaleDate: Required
    /// - Customer: Required, must be between 3 and 50 characters
    /// - Branch: Required, must be between 3 and 50 characters
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.SaleNumber).NotEmpty().Length(10, 50);
        RuleFor(x => x.SaleDate).Must(x => x != DateTime.MinValue);
        RuleFor(x => x.Customer).NotEmpty().Length(3, 50);
        RuleFor(x => x.Branch).NotEmpty().Length(3, 50);
    }
}