using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Domain.Entities.Oscillators;

/// <summary>
///     Contains information about the configuration of an Oscillator.
/// </summary>
public record OscillatorInformation
{
    /// <summary>
    ///     The waveform of the oscillator.
    /// </summary>
    public Waveform Waveform { get; init; } = Waveform.None;

    /// <summary>
    ///     Frequency of the Oscillator.
    /// </summary>
    public double Frequency { get; init; }

    /// <summary>
    ///     The amplitude of the Oscillator.
    /// </summary>
    [Range(0.0, 1.0)]
    public double Amplitude { get; init; }
}