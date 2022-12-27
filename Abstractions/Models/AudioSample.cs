using Synthesizer.Abstractions.Models.Ids;

namespace Synthesizer.Abstractions.Models;

/// <summary>
///     Contains an audio sample and meta-information about the sample.
/// </summary>
public struct AudioSample
{
    /// <summary>
    ///     The source of the audio sample.
    /// </summary>
    public SynthesizerId Source;

    /// <summary>
    ///     System time of audio sample generation for synchronization and error detection.
    /// </summary>
    public long Timestamp;

    /// <summary>
    ///     Audio samples.
    /// </summary>
    public int[] Samples;
}