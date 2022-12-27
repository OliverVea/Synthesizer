namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Base for id classes.
/// </summary>
public abstract record IdBase
{
    /// <summary>
    ///     The string containing the id value.
    /// </summary>
    protected readonly string Id;

    /// <summary>
    ///     Creates a new random id.
    /// </summary>
    public IdBase()
    {
        Id = Guid.NewGuid().ToString();
    }
}