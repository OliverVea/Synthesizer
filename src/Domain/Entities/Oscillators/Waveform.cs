namespace Synthesizer.Domain.Entities.Oscillators;

/// <summary>
///     Denotes a specific waveform for use in oscillators.
/// </summary>
public enum Waveform
{
    /// <summary>
    ///     Nothing.
    /// </summary>
    None,

    /// <summary>
    ///     At max amplitude constantly.
    /// </summary>
    Constant,

    /// <summary>
    ///     A sinusoidal waveform.
    /// </summary>
    Sine,

    /// <summary>
    ///     A sawtooth waveform.
    /// </summary>
    Sawtooth,

    /// <summary>
    ///     A triangle waveform.
    /// </summary>
    Triangle,

    /// <summary>
    ///     A square waveform.
    /// </summary>
    Square,

    /// <summary>
    ///     Random noise.
    /// </summary>
    Noise
}