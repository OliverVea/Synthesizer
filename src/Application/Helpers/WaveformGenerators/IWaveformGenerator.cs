using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public interface IWaveformGenerator
{
    public Waveform Waveform { get; }

    public void GenerateSamples(double[] sampleBuffer,
        double sampleRate,
        double amplitude,
        double frequency,
        double offset);
}