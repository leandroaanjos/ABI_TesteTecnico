using Ambev.DeveloperEvaluation.Integration.Config;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Json;

namespace Ambev.DeveloperEvaluation.Integration
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class ProductFixtureTest
    {
        private readonly IntegrationTestFixture<Program> _integrationTestFixture;

        public ProductFixtureTest(IntegrationTestFixture<Program> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        public static TheoryData<CreateProductRequest, string> InvalidProducts => new()
        {
            {
                new CreateProductRequest
                {
                    Title = "",
                    Description = "Test description",
                    Category = "Category 1",
                    Image = "http://images/product.jpg"
                }, "'Title' must not be empty."
            },
            {
                new CreateProductRequest
                {
                    Title = "Pr",
                    Description = "Test description",
                    Category = "Category 1",
                    Image = "http://images/product.jpg"
                }, "'Title' must be between 3 and 50 characters. You entered 2 characters."
            }
        };

        [Theory(DisplayName = "Post product with validation problems")]
        [MemberData(nameof(InvalidProducts))]
        public async Task Post_Product_With_Validation_Problems(CreateProductRequest createProductRequest, string errorMessage)
        {
            // Arrange
            var response = await _integrationTestFixture.Client.PostAsJsonAsync("/api/Products", createProductRequest);

            // Act            
            var problemResult = await response.Content.ReadFromJsonAsync<HttpValidationProblemDetails>();

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.NotNull(problemResult?.Errors);
            Assert.Collection(problemResult.Errors, (error) => Assert.Equal(errorMessage, error.Value.First()));
        }
    }
}
