using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class SineGenerator : IWaveformGenerator
{
    public Waveform Waveform => Waveform.Sine;

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