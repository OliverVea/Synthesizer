using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class TriangleGenerator : IWaveformGenerator
{
    public Waveform Waveform => Waveform.Triangle;

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