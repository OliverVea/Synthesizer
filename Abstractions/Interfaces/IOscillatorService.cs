using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;

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

    /// <summary>
    ///     Lists all available oscillators.
    /// </summary>
    /// <returns></returns>
    OscillatorInformation[] ListOscillators();

    /// <summary>
    ///     Creates a new Oscillator with the provided configuration.
    /// </summary>
    /// <param name="request">The configuration of the new oscillator.</param>
    void CreateOscillator(CreateOscillatorRequest request);
}