using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Title: Required, must be between 3 and 50 characters
    /// - Price: Required
    /// - Description: Required, must be between 3 and 100 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Must be between 3 and 100 characters    
    /// </remarks>
    public CreateProductCommandValidator()
    {        
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Price).NotEmpty();
        RuleFor(product => product.Description).NotEmpty().Length(3, 100);
        RuleFor(product => product.Category).NotEmpty().Length(3, 50);
        RuleFor(product => product.Image).MaximumLength(100);
    }
}