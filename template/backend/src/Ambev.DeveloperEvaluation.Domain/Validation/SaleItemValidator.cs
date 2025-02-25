using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.Quantity)
            .Must(x => x <= 20)
            .WithMessage($"{nameof(SaleItem.Quantity)} must be less or equal to twenty.");

        RuleFor(x => x.UnitPrice)
            .Must(x => x >= 0)
            .WithMessage($"{nameof(SaleItem.UnitPrice)} must be greater or equal to zero.");        
    }
}
