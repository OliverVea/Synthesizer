﻿using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;

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

    /// <summary>
    ///     Lists all available oscillators.
    /// </summary>
    /// <returns></returns>
    OscillatorInformation[] ListOscillators();

    /// <summary>
    ///     Sets the Oscillator with the provided id to be equal to the configuration.
    /// </summary>
    /// <param name="id">Id of the Oscillator</param>
    /// <param name="oscillatorInformation">Configuration of the Oscillator</param>
    void SetOscillator(OscillatorId id, OscillatorInformation oscillatorInformation);
}