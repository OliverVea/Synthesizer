using Synthesizer.Application.Helpers.WaveformGenerators;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers;

public class WaveformHelper : IWaveformHelper
{
    private readonly IReadOnlyDictionary<Waveform, IWaveformGenerator> _waveformGenerators;

    public WaveformHelper(IEnumerable<IWaveformGenerator> waveformGenerators)
    {
        _waveformGenerators = waveformGenerators.ToDictionary(x => x.Waveform);
    }

    public void GenerateSamples(
        double[] sampleBuffer,
        int sampleRate,
        double amplitude,
        double frequency,
        Waveform waveform,
        double offset = 0)
    {
        _waveformGenerators[waveform].GenerateSamples(
            sampleBuffer,
            sampleRate,
            amplitude,
            frequency,
            offset);
    }
}