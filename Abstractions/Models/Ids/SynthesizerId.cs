namespace Synthesizer.Abstractions.Models.Ids;

/// <summary>
///     Wrapper class for a Synthesizer id.
/// </summary>
public record SynthesizerId : IdBase
{
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