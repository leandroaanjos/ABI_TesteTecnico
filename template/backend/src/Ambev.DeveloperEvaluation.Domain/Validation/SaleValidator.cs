using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .MinimumLength(10).WithMessage($"{nameof(Sale.SaleNumber)} must be at least 10 characters long.")
            .MaximumLength(50).WithMessage($"{nameof(Sale.SaleNumber)} cannot be longer than 50 characters.");

        RuleFor(x => x.SaleDate)
            .Must(x => x != DateTime.MinValue)
            .WithMessage($"{nameof(Sale.SaleDate)} is required.");

        RuleFor(x => x.Customer)
            .NotEmpty()
            .MinimumLength(3).WithMessage($"{nameof(Sale.Customer)} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage($"{nameof(Sale.Customer)} cannot be longer than 50 characters.");

        RuleFor(x => x.Branch)
            .NotEmpty()
            .MinimumLength(3).WithMessage($"{nameof(Sale.Branch)} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage($"{nameof(Sale.Branch)} cannot be longer than 50 characters.");

        // TODO Validate the SaleItem fields
    }
}
