using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;

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

    public void CreateOscillator(CreateOscillatorRequest request)
    {
        var oscillatorId = new OscillatorId();
        var oscillatorInformation = new OscillatorInformation();

        _store.SetOscillator(oscillatorId, oscillatorInformation);
    }
}