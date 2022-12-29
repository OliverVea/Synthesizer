namespace Synthesizer.Application.Helpers.WaveformGenerators;

public interface IWaveformGenerator
{
    public void GenerateSamples(double[] sampleBuffer,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset);
}