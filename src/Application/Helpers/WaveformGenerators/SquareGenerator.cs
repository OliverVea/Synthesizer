using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class SquareGenerator : IWaveformGenerator
{
    public Waveform Waveform => Waveform.Square;

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