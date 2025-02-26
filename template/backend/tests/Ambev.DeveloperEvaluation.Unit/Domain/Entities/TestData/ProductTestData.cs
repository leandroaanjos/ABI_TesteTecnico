using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using Bogus.Extensions;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// ...    
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(x => x.Title, f => f.Commerce.ProductName().ClampLength(3, 50))
        .RuleFor(x => x.Description, f => f.Commerce.ProductDescription().ClampLength(3, 100))
        .RuleFor(x => x.Category, f => f.Commerce.Categories(1).First().ClampLength(3, 50))
        .RuleFor(x => x.Image, f => f.Image.PicsumUrl(250, 250).ClampLength(0, 100));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid title.
    /// The generated title will:
    /// - Be between 3 and 50 characters
    /// - Use commerce title conventions
    /// - Contain only valid characters
    /// </summary>
    /// <returns>A valid title.</returns>
    public static string GenerateValidProductTitle()
    {
        return new Faker().Commerce.ProductName().ClampLength(3, 50);
    }

    /// <summary>
    /// Generates a title that exceeds the maximum length limit.
    /// The generated title will:
    /// - Be longer than 51 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing title length validation error cases.
    /// </summary>
    /// <returns>A title that exceeds the maximum length limit.</returns>
    public static string GenerateLongTitle()
    {
        return new Faker().Random.AlphaNumeric(51);
    }

    /// <summary>
    /// Generates a description that exceeds the maximum length limit.
    /// The generated description will:
    /// - Be longer than 100 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing description length validation error cases.
    /// </summary>
    /// <returns>A description that exceeds the maximum length limit.</returns>
    public static string GenerateLongDescription()
    {
        return new Faker().Random.AlphaNumeric(101);
    }

    /// <summary>
    /// Generates a category that exceeds the maximum length limit.
    /// The generated category will:
    /// - Be longer than 51 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing category length validation error cases.
    /// </summary>
    /// <returns>A category that exceeds the maximum length limit.</returns>
    public static string GenerateInvalidCategory()
    {
        return new Faker().Random.AlphaNumeric(51);
    }

    /// <summary>
    /// Generates a image that exceeds the maximum length limit.
    /// The generated image will:
    /// - Be longer than 101 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing image length validation error cases.
    /// </summary>
    /// <returns>A image that exceeds the maximum length limit.</returns>
    public static string GenerateInvalidImage()
    {
        return new Faker().Random.AlphaNumeric(101);
    }
}
