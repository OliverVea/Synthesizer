using Synthesizer.Abstractions.Models;
using Synthesizer.Abstractions.Models.Ids;

namespace Synthesizer.Abstractions.Interfaces;

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