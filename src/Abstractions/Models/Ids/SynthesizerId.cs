namespace Synthesizer.Abstractions.Models.Ids;

/// <summary>
///     Wrapper class for a Synthesizer id.
/// </summary>
public record SynthesizerId : IdBase
{
    /// <summary>
    ///     Constructor for randomly generating a new id.
    /// </summary>
    public SynthesizerId()
    {
    }

    /// <summary>
    ///     Constructor for creating an id object from an existing id.
    /// </summary>
    /// <param name="id"></param>
    public SynthesizerId(string id) : base(id)
    {
    }

    /// <inheritdoc />
    public virtual bool Equals(SynthesizerId? other)
    {
        return Id == other?.Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}