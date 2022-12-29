using Synthesizer.Domain.Entities;
using Synthesizer.Domain.Entities.Ids;

namespace Synthesizer.Domain.Services;

/// <summary>
/// Used to get a SynthesizerConfiguration, which can be used to generate audio.
/// </summary>
public interface ISynthesizerConfigurationService
{
    /// <summary>
    /// Used to get a SynthesizerConfiguration, which can be used to generate audio based on the Synthesizer.
    /// </summary>
    /// <param name="synthesizerId">The Synthesizer to generate a SynthesizerGeneration for</param>
    SynthesizerConfiguration GetSynthesizerConfiguration(SynthesizerId synthesizerId);
}