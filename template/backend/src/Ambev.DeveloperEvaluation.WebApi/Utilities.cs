using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi
{
    public static class Utilities
    {
        public static ValidationProblemDetails ToValidationProblemDetails(this FluentValidation.Results.ValidationResult validationResult, string? title = null, int? status = null)
        {
            var errors = validationResult.Errors
                .GroupBy(x => x.PropertyName, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray(), StringComparer.OrdinalIgnoreCase);

            return new ValidationProblemDetails(errors);
        }
    }
}
