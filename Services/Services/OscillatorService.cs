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

    public OscillatorInformation GetOscillator(OscillatorId id)
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
            WaveForm = request.Waveform,
            Frequency = request.Frequency,
            Amplitude = request.Amplitude
        };

        _store.SetOscillator(oscillatorId, oscillatorInformation);

        return oscillatorId;
    }
}