using System.ComponentModel.DataAnnotations;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Domain.Entities;

/// <summary>
/// Used to generate audio samples.
/// </summary>
public struct SynthesizerConfiguration
{
    /// <summary>
    /// Constructor of SynthesizerConfiguration
    /// </summary>
    /// <param name="sampleRate">The sample rate of the generated output samples</param>
    /// <param name="masterVolume">Master volume of the synthesizer</param>
    /// <param name="waveform">Waveform of the synthesizer</param>
    /// <param name="frequency">Frequency of the synthesizer</param>
    /// <param name="amplitude">Amplitude of the synthesizer</param>
    public SynthesizerConfiguration(
        int sampleRate,
        double masterVolume,
        Waveform waveform,
        double frequency,
        double amplitude)
    {
        SampleRate = sampleRate;
        MasterVolume = masterVolume;
        Waveform = waveform;
        Frequency = frequency;
        Amplitude = amplitude;
    }

    /// <summary>
    /// The sample rate of the generated output samples.
    /// </summary>
    [Range(1, int.MaxValue)] public readonly int SampleRate;

    /// <summary>
    /// Master volume of the synthesizer.
    /// </summary>
    [Range(0.0, 1.0)] public readonly double MasterVolume;

    /// <summary>
    /// Waveform of the synthesizer.
    /// </summary>
    public readonly Waveform Waveform;

    /// <summary>
    /// Frequency of the synthesizer.
    /// </summary>
    [Range(double.Epsilon, double.MaxValue)]
    public readonly double Frequency;

    /// <summary>
    /// Amplitude of the synthesizer.
    /// </summary>
    [Range(0.0, 1.0)] public readonly double Amplitude;
}