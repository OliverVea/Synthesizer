namespace Synthesizer.Domain.Entities;

/// <summary>
/// Used to contain audio samples.
/// </summary>
public struct AudioSample
{
    /// <summary>
    /// The generated audio samples.
    /// </summary>
    public readonly double[] AudioSamples { get; init; }
}