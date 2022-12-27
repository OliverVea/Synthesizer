using Synthesizer.Abstractions.Models;

namespace Synthesizer.Abstractions.Interfaces;

/// <summary>
///     Used to store Oscillators.
/// </summary>
public interface IOscillatorStore
{
    /// <summary>
    ///     Gets an Oscillator from the provided id.
    /// </summary>
    /// <param name="id">The Oscillator id</param>
    OscillatorInformation GetOscillator(OscillatorId id);
}