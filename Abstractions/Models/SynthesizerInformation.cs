namespace Synthesizer.Abstractions.Models;

public record SynthesizerInformation
{
    public Waveform Waveform { get; set; }
    public string DisplayName { get; set; }
    public int SampleRate { get; set; }
}