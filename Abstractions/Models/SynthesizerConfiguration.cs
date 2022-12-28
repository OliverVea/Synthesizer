using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models;

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
    public double MasterVolume { get; set; }
}