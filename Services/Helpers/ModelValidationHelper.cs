using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Services.Helpers;

public static class ModelValidationHelper
{
    public static List<ValidationResult> Validate<TEntity>(this TEntity item) where TEntity : class
    {
        var validationResult = new List<ValidationResult>();

        var validationContext = new ValidationContext(item, null, null);

        Validator.TryValidateObject(item, validationContext, validationResult, true);

        return validationResult;
    }
}