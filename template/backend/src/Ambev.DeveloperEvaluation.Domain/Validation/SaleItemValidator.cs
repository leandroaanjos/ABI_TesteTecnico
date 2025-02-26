using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.Quantity)
            .Must(x => x >= 1 && x <= 20)
            .WithMessage($"{nameof(SaleItem.Quantity)} must be between 1 and 20 units.");

        RuleFor(x => x.UnitPrice)
            .Must(x => x >= 0)
            .WithMessage($"{nameof(SaleItem.UnitPrice)} must be greater or equal to zero.");        
    }
}
