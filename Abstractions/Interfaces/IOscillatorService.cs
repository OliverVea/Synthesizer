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
    OscillatorInformation? GetOscillator(OscillatorId id);

    /// <summary>
    ///     Lists all available oscillators.
    /// </summary>
    /// <returns></returns>
    OscillatorInformation[] ListOscillators();

    /// <summary>
    ///     Creates a new Oscillator with the provided configuration.
    /// </summary>
    /// <param name="request">The configuration of the new oscillator.</param>
    OscillatorId CreateOscillator(CreateOscillatorRequest request);

    /// <summary>
    /// Deletes the specified Oscillator.
    /// </summary>
    /// <param name="id">Id of the Oscillator</param>
    void DeleteOscillator(OscillatorId id);

    /// <summary>
    /// Used to update an Oscillator.
    /// </summary>
    /// <param name="request">Data used to identify and update the Oscillator.</param>
    void UpdateOscillator(UpdateOscillatorRequest request);
}