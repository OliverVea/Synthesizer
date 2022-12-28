using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Domain.Interfaces;

/// <summary>
///     Used to manage and use Oscillators.
/// </summary>
public interface IOscillatorService
{
    /// <summary>
    ///     Gets an Oscillator from the provided id. Returns null if an Oscillator could not be found.
    /// </summary>
    /// <param name="oscillatorId">The Oscillator id</param>
    OscillatorInformation? GetOscillator(OscillatorId oscillatorId);

    /// <summary>
    ///     Gets an Oscillator from the provided id. Throws ArgumentException if an Oscillator could not be found.
    /// </summary>
    /// <param name="oscillatorId">The Oscillator id</param>
    OscillatorInformation GetRequiredOscillator(OscillatorId oscillatorId);

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
    /// <param name="oscillatorId">Id of the Oscillator</param>
    void DeleteOscillator(OscillatorId oscillatorId);

    /// <summary>
    /// Used to update an Oscillator.
    /// </summary>
    /// <param name="request">Data used to identify and update the Oscillator.</param>
    void UpdateOscillator(UpdateOscillatorRequest request);
}