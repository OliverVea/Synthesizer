using Synthesizer.Domain.Entities;
using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application.Services;

public class SynthesizingService : ISynthesizingService
{
    public AudioSample GenerateSamples(int sampleCount,
        SynthesizerConfiguration synthesizerConfiguration,
        double offset)
    {
        return new AudioSample
        {
            AudioSamples = new double[sampleCount]
        };
    }
}