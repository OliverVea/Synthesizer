using Synthesizer.Application.Helpers.WaveformGenerators;
using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers;

public class WaveformHelper : IWaveformHelper
{
    private readonly IReadOnlyDictionary<Waveform, IWaveformGenerator> _waveformGenerators =
        new Dictionary<Waveform, IWaveformGenerator>
        {
            { Waveform.None, new NoneGenerator() },
            { Waveform.Sawtooth, new SawtoothGenerator() },
            { Waveform.Sine, new SineGenerator() },
            { Waveform.Square, new SquareGenerator() },
            { Waveform.Triangle, new TriangleGenerator() }
        };

    public void GenerateSamples(
        double[] sampleBuffer,
        int sampleCount,
        int sampleRate,
        double amplitude,
        double frequency,
        Waveform waveform,
        double offset = 0)
    {
        _waveformGenerators[waveform]
            .GenerateSamples(sampleBuffer, sampleCount, sampleRate, amplitude, frequency, offset);
    }
}