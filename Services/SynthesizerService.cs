using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;

namespace Synthesizer.Services;

public class SynthesizerService : ISynthesizerService
{
    private readonly ISynthesizerStore _store;

    public SynthesizerService(ISynthesizerStore store)
        => _store = store;

    public SynthesizerId CreateSynthesizer(CreateSynthesizerRequest request)
    {
        var synthesizerId = SynthesizerId.NewId();

        var synthesizerInformation = new SynthesizerInformation
        {
            Waveform = request.Waveform,
            DisplayName = request.DisplayName,
            SampleRate = request.SampleRate
        };

        _store.SetSynthesizer(synthesizerId, synthesizerInformation);

        return synthesizerId;
    }

    public AudioSample GetNextSamples(SynthesizerId id, int sampleCount)
    {
        throw new NotImplementedException();
    }
}