using System.ComponentModel.DataAnnotations;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Domain.Entities;

/// <summary>
/// Used to generate audio samples.
/// </summary>
public struct SynthesizerConfiguration
{
    /// <summary>
    /// The sample rate of the generated output samples.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int SampleRate { get; init; }

    /// <summary>
    /// Master volume of the synthesizer.
    /// </summary>
    [Range(0.0, 1.0)]
    public double MasterVolume { get; init; }

    /// <summary>
    /// Waveform of the synthesizer.
    /// </summary>
    public Waveform Waveform { get; init; }

    /// <summary>
    /// Frequency of the synthesizer.
    /// </summary>
    [Range(double.Epsilon, double.MaxValue)]
    public double Frequency { get; init; }

    /// <summary>
    /// Amplitude of the synthesizer.
    /// </summary>
    [Range(0.0, 1.0)]
    public double Amplitude { get; init; }
}