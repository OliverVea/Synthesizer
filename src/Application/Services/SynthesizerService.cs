using Synthesizer.Application.Helpers;
using Synthesizer.Application.Infrastructure;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Synthesizers;
using Synthesizer.Domain.Exceptions;
using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application.Services;

public class SynthesizerService : ISynthesizerService
{
    private readonly ISynthesizerStore _store;

    public SynthesizerService(ISynthesizerStore store)
    {
        _store = store;
    }

    public SynthesizerId CreateSynthesizer(CreateSynthesizerRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var synthesizerId = new SynthesizerId();

        var synthesizerInformation = new SynthesizerInformation
        {
            DisplayName = request.DisplayName,
            SampleRate = request.SampleRate,
            MasterVolume = request.MasterVolume,
            OscillatorId = request.OscillatorId
        };

        _store.SetSynthesizer(synthesizerId, synthesizerInformation);

        return synthesizerId;
    }

    public SynthesizerInformation? GetSynthesizer(SynthesizerId synthesizerId)
    {
        return _store.GetSynthesizer(synthesizerId);
    }

    public SynthesizerInformation GetRequiredSynthesizer(SynthesizerId synthesizerId)
    {
        return GetRequiredSynthesizer(synthesizerId, nameof(synthesizerId));
    }

    private SynthesizerInformation GetRequiredSynthesizer(SynthesizerId synthesizerId, string parameterName)
    {
        var synthesizer = GetSynthesizer(synthesizerId);
        if (synthesizer == null) throw new NoSynthesizerWithIdException(synthesizerId, parameterName);

        return synthesizer;
    }

    public IEnumerable<SynthesizerInformation> ListSynthesizers()
    {
        return _store.ListSynthesizers();
    }

    public void DeleteSynthesizer(SynthesizerId synthesizerId)
    {
        _store.DeleteSynthesizer(synthesizerId);
    }

    public void SetOscillatorId(SynthesizerId synthesizerId, OscillatorId? oscillatorId)
    {
        var currentSynthesizer = GetRequiredSynthesizer(synthesizerId, nameof(synthesizerId));

        var updatedSynthesizer = currentSynthesizer with
        {
            OscillatorId = oscillatorId
        };

        _store.SetSynthesizer(synthesizerId, updatedSynthesizer);
    }

    public void UpdateSynthesizer(UpdateSynthesizerRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var currentSynthesizer = GetRequiredSynthesizer(request.SynthesizerId, nameof(request.SynthesizerId));

        var updatedSynthesizer = currentSynthesizer with
        {
            MasterVolume = request.MasterVolume ?? currentSynthesizer.MasterVolume,
            DisplayName = request.DisplayName ?? currentSynthesizer.DisplayName
        };

        _store.SetSynthesizer(request.SynthesizerId, updatedSynthesizer);
    }
}