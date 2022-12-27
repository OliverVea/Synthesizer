using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Application.Helpers;

public static class ModelValidationHelper
{
    private static List<ValidationResult> ValidateModel<TEntity>(this TEntity item) where TEntity : class
    {
        var validationResult = new List<ValidationResult>();
        var validationContext = new ValidationContext(item, null, null);
        Validator.TryValidateObject(item, validationContext, validationResult, true);
        return validationResult;
    }

    public static void ThrowModelErrors<TEntity>(this TEntity item, string parameterName) where TEntity : class
    {
        var validationErrors = item.ValidateModel();
        if (validationErrors.Any())
        {
            var errors = string.Join('\n', validationErrors);
            throw new ArgumentException($"Parameter had following errors:\n{errors}", parameterName);
        }
    }
}