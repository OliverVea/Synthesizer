namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Wrapper class for a Synthesizer id.
/// </summary>
public record SynthesizerId
{
    private string _id;

    private SynthesizerId(Guid guid)
    {
        _id = guid.ToString();
    }

    /// <summary>
    ///     Creates a new Synthesizer id from a Guid.
    /// </summary>
    /// <returns>The new id</returns>
    public static SynthesizerId NewId()
    {
        return new SynthesizerId(Guid.NewGuid());
    }
}