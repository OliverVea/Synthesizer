using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Contains information about a Synthesizer configuration.
/// </summary>
public record SynthesizerInformation
{
    /// <summary>
    ///     Human-readable display name of the synthesizer.
    /// </summary>
    public string DisplayName { get; init; } = string.Empty;

    /// <summary>
    ///     Waveform of the synthesizer.
    /// </summary>
    public Waveform Waveform { get; init; } = Waveform.None;

    /// <summary>
    ///     Sample rate of the synthesizer.
    /// </summary>
    public int SampleRate { get; init; } = 44100;

    /// <summary>
    ///     Master volume of the synthesizer.
    /// </summary>

    [Range(0, 1.0, ErrorMessage = "Volume should be between 0 and 1.")]
    public double MasterVolume { get; init; } = 1.0;
}