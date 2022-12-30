namespace Synthesizer.Domain.Exceptions;

/// <summary>
/// Base class for exceptions where an entity could not be found with a provided id.
/// </summary>
public abstract class NoEntityWithIdException : ArgumentException
{
    private static string GetMessage(string entityDescription, string entityId)
    {
        return $"Could not find {entityDescription} with id '{entityId}'.";
    }

    /// <summary>
    /// Constructor for the base exception.
    /// </summary>
    /// <param name="entityDescription">Short description of the entity searched for</param>
    /// <param name="entityId">The id which is being searched with</param>
    /// <param name="parameterName">The parameter name of the id</param>
    protected NoEntityWithIdException(
        string entityDescription,
        string entityId,
        string parameterName) : base(GetMessage(entityDescription, entityId), parameterName)
    {
    }
}