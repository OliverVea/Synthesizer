using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Request used to create a new synthesizer.
/// </summary>
public record CreateSynthesizerRequest
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
    [Range(0, 1.0)]
    public double MasterVolume { get; init; } = 1.0;
}