using Synthesizer.Domain.Entities;

namespace Synthesizer.Domain.Interfaces;

/// <summary>
/// Used to generate audio samples from a SynthesizerConfiguration.
/// </summary>
public interface ISynthesizingService
{
    /// <summary>
    /// Use a synthesizer configuration to generate audio samples.
    /// </summary>
    /// <param name="synthesizerConfiguration">Configuration for the audio generation</param>
    /// <param name="sampleCount">Number of samples to generate</param>
    /// <param name="offset">Time offset of when to start generating</param>
    /// <returns>An object containing series of audio samples</returns>
    AudioSample GenerateSamples(SynthesizerConfiguration synthesizerConfiguration, int sampleCount, double offset);
}