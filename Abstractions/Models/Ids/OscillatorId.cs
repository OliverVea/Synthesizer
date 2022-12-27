namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Wrapper class for an Oscillator id.
/// </summary>
public record OscillatorId : IdBase
{
    /// <summary>
    ///     Constructor for randomly generating a new id.
    /// </summary>
    public OscillatorId()
    {
    }

    /// <summary>
    ///     Constructor for creating an id object from an existing id.
    /// </summary>
    /// <param name="id"></param>
    public OscillatorId(string id) : base(id)
    {
    }

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