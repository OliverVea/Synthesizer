using Synthesizer.Abstractions.Models.Oscillators;

namespace Synthesizer.Services.Helpers;

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