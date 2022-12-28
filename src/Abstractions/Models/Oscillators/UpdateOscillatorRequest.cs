using System.ComponentModel.DataAnnotations;
using Synthesizer.Abstractions.Models.Ids;

namespace Synthesizer.Abstractions.Models.Oscillators;

/// <summary>
/// Used to update an already existing Oscillator.
/// </summary>
public record UpdateOscillatorRequest(OscillatorId OscillatorId)
{
    /// <summary>
    /// The id of the Oscillator to update.
    /// </summary>
    public OscillatorId OscillatorId { get; init; } = OscillatorId;

    /// <summary>
    /// Set to update the amplitude of the Oscillator.
    /// </summary>
    [Range(0.0, 1.0)]
    public double? Amplitude { get; init; }

    /// <summary>
    /// Set to update the waveform of the Oscillator.
    /// </summary>
    public Waveform? Waveform { get; init; }

    /// <summary>
    /// Set to update the frequency of the Oscillator.
    /// </summary>
    [Range(double.Epsilon, double.MaxValue)]
    public double? Frequency { get; init; }
}