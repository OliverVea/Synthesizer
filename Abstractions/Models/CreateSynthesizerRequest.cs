using System.ComponentModel.DataAnnotations;

namespace Synthesizer.Abstractions.Models;

public record CreateSynthesizerRequest
{
    public string DisplayName { get; init; } = string.Empty;
    public Waveform Waveform { get; init; } = Waveform.None;
    public int SampleRate { get; init; } = 44100;

    [Range(0, 1.0, ErrorMessage = "Volume should be between 0 and 1.")]
    public double MasterVolume { get; init; } = 1.0;
}