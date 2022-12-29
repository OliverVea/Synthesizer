using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class NoiseGenerator : IWaveformGenerator
{
    public Waveform Waveform => Waveform.Noise;

    public void GenerateSamples(
        double[] sampleBuffer,
        double sampleRate,
        double amplitude,
        double frequency,
        double offset)
    {
        throw new NotImplementedException();
    }
}