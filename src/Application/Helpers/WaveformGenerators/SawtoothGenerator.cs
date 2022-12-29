namespace Synthesizer.Application.Helpers.WaveformGenerators;

public class SawtoothGenerator : IWaveformGenerator
{
    public void GenerateSamples(double[] sampleBuffer,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset)
    {
        var wavePeriod = 1 / frequency;
        var phase = offset % wavePeriod;

        for (var i = 0; i < sampleBuffer.Length; i++)
        {
            var t = phase + i * samplingFrequency;

            var sample = t % wavePeriod;
            if (sample < 0) sample += wavePeriod;

            sampleBuffer[i] = amplitude * sample * frequency;
        }
    }
}