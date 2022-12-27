using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models.Synthesizers;

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
    ///     Sample rate of the synthesizer.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int SampleRate { get; init; } = 44100;

    /// <summary>
    ///     Master volume of the synthesizer.
    /// </summary>
    [Range(0, 1.0)]
    public double MasterVolume { get; init; } = 1.0;
}