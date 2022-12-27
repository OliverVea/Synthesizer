namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Wrapper class for an Oscillator id.
/// </summary>
public record OscillatorId : IdBase
{
    /// <inheritdoc />
    public virtual bool Equals(OscillatorId? other)
    {
        return Id == other?.Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}