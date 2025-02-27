using Ambev.DeveloperEvaluation.WebApi;
using DeveloperEvaluation.Integration.Config;

namespace Ambev.DeveloperEvaluation.Integration.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class IntegrationApiTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<Program>>
    {
    }

    public class IntegrationTestFixture<TProgram> : IDisposable where TProgram : class
    {
        public readonly DeveloperEvaluationAppFactory<TProgram> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("https://localhost:7181"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new DeveloperEvaluationAppFactory<TProgram>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client?.Dispose();
            Factory?.Dispose();
        }
    }
}
