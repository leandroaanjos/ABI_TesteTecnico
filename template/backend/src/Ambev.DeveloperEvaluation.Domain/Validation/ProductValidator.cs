using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage($"{nameof(Product.Title)} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage($"{nameof(Product.Title)} cannot be longer than 50 characters.");

        RuleFor(x => x.Price)
            .Must(x => x >= 0)
            .WithMessage($"{nameof(Product.Price)} must be greater or equal to zero.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(3).WithMessage($"{nameof(Product.Description)} must be at least 3 characters long.")
            .MaximumLength(100).WithMessage($"{nameof(Product.Description)} cannot be longer than 100 characters.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage($"{nameof(Product.Category)} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage($"{nameof(Product.Category)} cannot be longer than 50 characters.");

        RuleFor(x => x.Image)
            .MinimumLength(3).WithMessage($"{nameof(Product.Image)} must be at least 3 characters long.")
            .MaximumLength(100).WithMessage($"{nameof(Product.Image)} cannot be longer than 100 characters.");
    }
}
