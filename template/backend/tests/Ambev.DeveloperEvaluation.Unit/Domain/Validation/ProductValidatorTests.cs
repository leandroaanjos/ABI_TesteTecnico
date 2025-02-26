using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all product properties.
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// This test verifies that a product with valid:    
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid title formats.
    /// This test verifies that titles that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 3 and 50 characters.
    /// </summary>
    /// <param name="title">The invalid title to test.</param>
    [Theory(DisplayName = "Invalid title formats should fail validation")]
    [InlineData("")] // Empty
    [InlineData("az")] // Less than 3 characters
    public void Given_InvalidProductTitle_When_Validated_Then_ShouldHaveError(string title)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = title;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    /// <summary>
    /// Tests that validation fails when title exceeds maximum length.
    /// This test verifies that titles longer than 50 characters fail validation.
    /// The test uses TestDataGenerator to create a title that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Prouducttitle longer than maximum length should fail validation")]
    public void Given_ProuducttitleLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = ProductTestData.GenerateLongTitle();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    // TODO create validations for other fields
}
