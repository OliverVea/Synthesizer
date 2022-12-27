using Synthesizer.Abstractions.Models;

namespace Synthesizer.Abstractions.Interfaces;

public interface ISynthesizerStore
{
    public SynthesizerInformation[] ListSynthesizers();
    public SynthesizerInformation GetSynthesizer(SynthesizerId id);
    public void SetSynthesizer(SynthesizerId id, SynthesizerInformation synthesizerInformation);
    public void DeleteSynthesizer(SynthesizerId id);
}