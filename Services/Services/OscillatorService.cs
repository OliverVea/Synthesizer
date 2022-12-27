using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;
using Synthesizer.Services.Helpers;

namespace Synthesizer.Services.Services;

public class OscillatorService : IOscillatorService
{
    private readonly IOscillatorStore _store;

    public OscillatorService(IOscillatorStore store)
    {
        _store = store;
    }

    public OscillatorInformation? GetOscillator(OscillatorId id)
    {
        return _store.GetOscillator(id);
    }

    public OscillatorInformation[] ListOscillators()
    {
        return _store.ListOscillators();
    }

    public OscillatorId CreateOscillator(CreateOscillatorRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var oscillatorId = new OscillatorId();

        var oscillatorInformation = new OscillatorInformation
        {
            Waveform = request.Waveform,
            Frequency = request.Frequency,
            Amplitude = request.Amplitude
        };

        _store.SetOscillator(oscillatorId, oscillatorInformation);

        return oscillatorId;
    }

    public void DeleteOscillator(OscillatorId id)
    {
        _store.DeleteOscillator(id);
    }

    public void UpdateOscillator(UpdateOscillatorRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var currentOscillator = _store.GetOscillator(request.OscillatorId);
        if (currentOscillator == null)
            throw new ArgumentException($"Could not find oscillator with id '{request.OscillatorId}.",
                nameof(request.OscillatorId));

        var newOscillator = currentOscillator with
        {
            Amplitude = request.Amplitude ?? currentOscillator.Amplitude,
            Frequency = request.Frequency ?? currentOscillator.Frequency,
            Waveform = request.Waveform ?? currentOscillator.Waveform
        };

        _store.SetOscillator(request.OscillatorId, newOscillator);
    }
}