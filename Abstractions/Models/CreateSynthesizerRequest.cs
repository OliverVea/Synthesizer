namespace Synthesizer.Abstractions.Models;

public record CreateSynthesizerRequest
{
    public string DisplayName { get; set; }
    public Waveform Waveform { get; set; }
    public int SampleRate { get; set; }
}