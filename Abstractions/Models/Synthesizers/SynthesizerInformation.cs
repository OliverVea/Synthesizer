using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models.Synthesizers;

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
    ///     Sample rate of the synthesizer.
    /// </summary>
    public int SampleRate { get; init; } = 44100;

    /// <summary>
    ///     Master volume of the synthesizer.
    /// </summary>

    [Range(0.0, 1.0)]
    public double MasterVolume { get; init; } = 1.0;
}