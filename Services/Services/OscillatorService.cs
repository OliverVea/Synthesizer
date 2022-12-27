using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;

namespace Synthesizer.Services.Services;

public class OscillatorService : IOscillatorService
{
    private readonly IOscillatorStore _store;

    public OscillatorService(IOscillatorStore store)
    {
        _store = store;
    }

    public void GetOscillator(OscillatorId id)
    {
        _store.GetOscillator(id);
    }
}