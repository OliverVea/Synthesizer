using Synthesizer.Application.Infrastructure;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Infrastructure;

public class OscillatorStore : IOscillatorStore
{
    private readonly Dictionary<OscillatorId, OscillatorInformation> _oscillators = new();

    public IEnumerable<OscillatorInformation> ListOscillators()
    {
        return _oscillators.Values.ToArray();
    }

    public OscillatorInformation GetOscillator(OscillatorId id)
    {
        if (!_oscillators.ContainsKey(id))
            throw new KeyNotFoundException($"An oscillator could not be found with id '{id}'.");

        return _oscillators[id];
    }

    public void SetOscillator(OscillatorId id, OscillatorInformation oscillatorInformation)
    {
        _oscillators[id] = oscillatorInformation;
    }

    public void DeleteOscillator(OscillatorId id)
    {
        _oscillators.Remove(id);
    }
}