using System.ComponentModel.DataAnnotations;
using Synthesizer.Domain.Entities.Ids;

namespace Synthesizer.Domain.Entities.Synthesizers;

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
    ///     Oscillator of the Synthesizer.
    /// </summary>
    public OscillatorId? OscillatorId { get; init; }

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