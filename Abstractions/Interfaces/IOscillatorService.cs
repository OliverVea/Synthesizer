using Synthesizer.Abstractions.Models;

namespace Synthesizer.Abstractions.Interfaces;

/// <summary>
///     Used to manage and use Oscillators.
/// </summary>
public interface IOscillatorService
{
    /// <summary>
    ///     Gets an Oscillator from the provided id.
    /// </summary>
    /// <param name="id">The Oscillator id</param>
    OscillatorInformation GetOscillator(OscillatorId id);
}