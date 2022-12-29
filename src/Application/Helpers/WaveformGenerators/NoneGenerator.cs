namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class NoneGenerator : IWaveformGenerator
{
    public void GenerateSamples(double[] sampleBuffer,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset)
    {
        for (var i = 0; i < sampleBuffer.Length; i++) sampleBuffer[i] = 0;
    }
}