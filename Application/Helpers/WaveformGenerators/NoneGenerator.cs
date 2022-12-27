namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class NoneGenerator : IWaveformGenerator
{
    public void GenerateSamples(
        double[] sampleBuffer,
        int sampleCount,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset)
    {
        for (var i = 0; i < sampleCount; i++) sampleBuffer[i] = 0;
    }
}