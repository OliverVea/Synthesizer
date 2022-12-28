using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers;

public interface IWaveformHelper
{
    void GenerateSamples(
        double[] sampleBuffer,
        int sampleCount,
        int sampleRate,
        double amplitude,
        double frequency,
        Waveform waveform,
        double offset = 0);
}