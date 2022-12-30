using Synthesizer.Application.Helpers;
using Synthesizer.Application.Infrastructure;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Oscillators;
using Synthesizer.Domain.Exceptions;
using Synthesizer.Domain.Services;

namespace Synthesizer.Application.Services;

public class OscillatorService : IOscillatorService
{
    private readonly IOscillatorStore _store;

    public OscillatorService(IOscillatorStore store)
    {
        _store = store;
    }

    public OscillatorInformation? GetOscillator(OscillatorId oscillatorId)
    {
        return _store.GetOscillator(oscillatorId);
    }

    public OscillatorInformation GetRequiredOscillator(OscillatorId oscillatorId)
    {
        return GetRequiredOscillator(oscillatorId, nameof(oscillatorId));
    }

    private OscillatorInformation GetRequiredOscillator(OscillatorId oscillatorId, string parameterName)
    {
        var oscillator = GetOscillator(oscillatorId);

        if (oscillator == null) throw new NoOscillatorWithIdException(oscillatorId, parameterName);

        return oscillator;
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

    public void DeleteOscillator(OscillatorId oscillatorId)
    {
        _store.DeleteOscillator(oscillatorId);
    }

    public void UpdateOscillator(UpdateOscillatorRequest request)
    {
        request.ThrowModelErrors(nameof(request));

        var currentOscillator = _store.GetOscillator(request.OscillatorId);
        if (currentOscillator == null)
            throw new NoOscillatorWithIdException(request.OscillatorId, nameof(request.OscillatorId));

        var newOscillator = currentOscillator with
        {
            Amplitude = request.Amplitude ?? currentOscillator.Amplitude,
            Frequency = request.Frequency ?? currentOscillator.Frequency,
            Waveform = request.Waveform ?? currentOscillator.Waveform
        };

        _store.SetOscillator(request.OscillatorId, newOscillator);
    }
}