namespace Synthesizer.Domain.Entities.Ids;

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
    protected IdBase()
    {
        Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    ///     Creates IdBase object from existing id string.
    /// </summary>
    /// <param name="id"></param>
    protected IdBase(string id)
    {
        Id = id;
    }
}