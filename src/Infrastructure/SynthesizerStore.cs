using Synthesizer.Application.Infrastructure;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Synthesizers;

namespace Synthesizer.Infrastructure;

public class SynthesizerStore : ISynthesizerStore
{
    private readonly Dictionary<SynthesizerId, SynthesizerInformation> _synthesizers = new();

    public SynthesizerInformation[] ListSynthesizers()
    {
        return _synthesizers.Values.ToArray();
    }

    public SynthesizerInformation GetSynthesizer(SynthesizerId id)
    {
        if (!_synthesizers.ContainsKey(id))
            throw new KeyNotFoundException($"A synthesizer could not be found with id '{id}'.");

        return _synthesizers[id];
    }

    public void SetSynthesizer(SynthesizerId id, SynthesizerInformation synthesizerInformation)
    {
        _synthesizers[id] = synthesizerInformation;
    }

    public void DeleteSynthesizer(SynthesizerId id)
    {
        _synthesizers.Remove(id);
    }
}