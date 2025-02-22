using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 50 characters
    /// - Price: Required
    /// - Description: Required, must be between 3 and 100 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Must be between 3 and 100 characters    
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Price).NotEmpty();
        RuleFor(product => product.Description).NotEmpty().Length(3, 100);
        RuleFor(product => product.Category).NotEmpty().Length(3, 50);
        RuleFor(product => product.Image).Length(3, 100);
    }
}