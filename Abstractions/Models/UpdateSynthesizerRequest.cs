using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Used to update the configuration of a Synthesizer.
/// </summary>
/// <param name="SynthesizerId">The id of the synthesizer to update.</param>
public record UpdateSynthesizerRequest(SynthesizerId SynthesizerId)
{
    /// <summary>
    ///     The id of the synthesizer to update.
    /// </summary>
    public SynthesizerId SynthesizerId { get; set; } = SynthesizerId;

    /// <summary>
    ///     Set to update the human-readable display name of the synthesizer.
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    ///     Set to update the master volume of the synthesizer.
    /// </summary>
    [Range(0.0, 1.0)]
    public double? MasterVolume { get; set; }
}