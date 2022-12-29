using Synthesizer.Domain.Entities.Oscillators;

namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class NoneGenerator : IWaveformGenerator
{
    public Waveform Waveform => Waveform.None;

    public void GenerateSamples(
        double[] sampleBuffer,
        double sampleRate,
        double amplitude,
        double frequency,
        double offset)
    {
        for (var i = 0; i < sampleBuffer.Length; i++) sampleBuffer[i] = 0;
    }
}