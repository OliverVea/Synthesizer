﻿using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Synthesizers;
using Synthesizer.Services.Helpers;

namespace Synthesizer.Services.Services;

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
            Waveform = request.Waveform,
            DisplayName = request.DisplayName,
            SampleRate = request.SampleRate,
            MasterVolume = request.MasterVolume
        };

        _store.SetSynthesizer(synthesizerId, synthesizerInformation);

        return synthesizerId;
    }

    public SynthesizerInformation? GetSynthesizer(SynthesizerId id)
    {
        return _store.GetSynthesizer(id);
    }

    public SynthesizerInformation[] ListSynthesizers()
    {
        return _store.ListSynthesizers();
    }

    public void DeleteSynthesizer(SynthesizerId id)
    {
        _store.DeleteSynthesizer(id);
    }

    public AudioSample GetNextSamples(SynthesizerId id, int sampleCount)
    {
        throw new NotImplementedException();
    }

    public void UpdateSynthesizer(UpdateSynthesizerRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var currentSynthesizer = GetSynthesizer(request.SynthesizerId);

        if (currentSynthesizer == null)
            throw new ArgumentException($"Could not find synthesizer with id '{request.SynthesizerId}'.",
                nameof(request.SynthesizerId));

        var updatedSynthesizer = currentSynthesizer with
        {
            MasterVolume = request.MasterVolume ?? currentSynthesizer.MasterVolume,
            DisplayName = request.DisplayName ?? currentSynthesizer.DisplayName
        };

        _store.SetSynthesizer(request.SynthesizerId, updatedSynthesizer);
    }
}