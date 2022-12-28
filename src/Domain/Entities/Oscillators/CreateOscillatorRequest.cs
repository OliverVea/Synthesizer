using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Domain.Entities.Oscillators;

/// <summary>
///     Request to create a new Oscillator.
/// </summary>
public record CreateOscillatorRequest
{
    /// <summary>
    ///     The waveform of the Oscillator.
    /// </summary>
    public Waveform Waveform { get; init; } = Waveform.None;

    /// <summary>
    ///     The frequency of the Oscillator.
    /// </summary>
    [Range(double.Epsilon, double.MaxValue)]
    public double Frequency { get; init; }

    /// <summary>
    ///     The amplitude of the Oscillator.
    /// </summary>
    [Range(0.0, 1.0)]
    public double Amplitude { get; init; }
}