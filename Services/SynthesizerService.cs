using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Services.Helpers;

namespace Synthesizer.Services;

public class SynthesizerService : ISynthesizerService
{
    private readonly ISynthesizerStore _store;

    public SynthesizerService(ISynthesizerStore store)
    {
        _store = store;
    }

    public SynthesizerId CreateSynthesizer(CreateSynthesizerRequest request)
    {
        var validationErrors = request.Validate();
        if (validationErrors.Any())
        {
            var errors = string.Join('\n', validationErrors);
            throw new ArgumentException($"Parameter had following errors:\n{errors}", nameof(request));
        }

        var synthesizerId = SynthesizerId.NewId();

        var synthesizerInformation = new SynthesizerInformation
        {
            Waveform = request.Waveform,
            DisplayName = request.DisplayName,
            SampleRate = request.SampleRate,
            MasterVolume = request.MasterVolume
        };

        _store.SetSynthesizer(synthesizerId, synthesizerInformation);

        return synthesizerId;
    }

    public AudioSample GetNextSamples(SynthesizerId id, int sampleCount)
    {
        throw new NotImplementedException();
    }

    public SynthesizerInformation? GetSynthesizer(SynthesizerId id)
    {
        return _store.GetSynthesizer(id);
    }

    public SynthesizerInformation[] ListSynthesizers()
    {
        return _store.ListSynthesizers();
    }
}