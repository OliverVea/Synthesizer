namespace Synthesizer.Application.Helpers.WaveformGenerators;

public interface IWaveformGenerator
{
    public void GenerateSamples(
        double[] sampleBuffer,
        int sampleCount,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset);
}