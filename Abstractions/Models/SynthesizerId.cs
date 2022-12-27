namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Wrapper class for a Synthesizer id.
/// </summary>
public record SynthesizerId
{
    private readonly string _id;

    private SynthesizerId(Guid guid)
    {
        _id = guid.ToString();
    }

    /// <inheritdoc />
    public virtual bool Equals(SynthesizerId? other)
    {
        return _id == other?._id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _id.GetHashCode();
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