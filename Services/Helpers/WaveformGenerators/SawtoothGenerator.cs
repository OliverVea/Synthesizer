namespace Synthesizer.Services.Helpers.WaveformGenerators;

public class SawtoothGenerator : IWaveformGenerator
{
    public void GenerateSamples(
        double[] sampleBuffer,
        int sampleCount,
        double samplingFrequency,
        double amplitude,
        double frequency,
        double offset)
    {
        double wavePeriod = 1 / frequency;
        var phase = offset % wavePeriod;
        
        for (var i = 0; i < sampleCount; i++)
        {
            var t = phase + i * samplingFrequency;

            var sample = t % wavePeriod;
            if (sample < 0) sample += wavePeriod;
            
            sampleBuffer[i] = amplitude * sample * frequency;
        }
    }
}