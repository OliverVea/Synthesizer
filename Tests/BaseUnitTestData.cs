using Synthesizer.Abstractions.Models.Oscillators;

namespace Tests;

public partial class BaseUnitTest
{
    protected static readonly Waveform[] Waveforms =
    {
        Waveform.None,
        Waveform.Constant,
        Waveform.Sawtooth,
        Waveform.Sine,
        Waveform.Square,
        Waveform.Triangle,
        Waveform.Noise
    };

    protected static readonly int[] SampleRates =
    {
        // ReSharper disable CommentTypo
        8000, // Adequate for human speech but without sibilance. Used in telephone/walkie-talkie.
        11025, // Used for lower-quality PCM, MPEG audio and for audio analysis of subwoofer bandpasses.
        16000, // Used in most VoIP and VVoIP, extension of telephone narrowband.
        22050, // Used for lower-quality PCM and MPEG audio and for audio analysis of low frequency energy.
        44100, // Audio CD, most commonly used rate with MPEG-1 audio (VCD, SVCD, MP3). Covers the 20 kHz bandwidth.
        48000, // Standard sampling rate used by professional digital video equipment, could reconstruct frequencies up to 22 kHz.
        88200, // Used by some professional recording equipment when the destination is CD, such as mixers, EQs, compressors, reverb, crossovers and recording devices.
        96000, // DVD-Audio, LPCM DVD tracks, Blu-ray audio tracks, HD DVD audio tracks.
        176400, // Used in HDCD recorders and other professional applications for CD production.
        192000, // Used with audio on professional video equipment. DVD-Audio, LPCM DVD tracks, Blu-ray audio tracks, HD DVD audio tracks.
        352800, // Digital eXtreme Definition. Used for recording and editing Super Audio CDs.
        374000, // Highest sample rate available for common software. Allows for precise peak detection.
        int.MaxValue
        // ReSharper enable CommentTypo
    };

    protected static readonly int[] InvalidSampleRates =
    {
        int.MinValue,
        0
    };

    protected static readonly double[] Amplitudes =
    {
        double.NegativeZero,
        double.Epsilon,
        0.0,
        0.001,
        0.5,
        0.999,
        1.0
    };

    protected static readonly double[] InvalidAmplitudes =
    {
        double.NaN,
        double.NegativeInfinity,
        double.PositiveInfinity,
        double.MinValue,
        double.MaxValue,
        0.0 - 1e-10,
        1.0 + 1e-10
    };

    protected static readonly double[] Frequencies =
    {
        0.001,
        1.0,
        100.0 / 3.0,
        1000.0,
        10000.0,
        100000.0
    };

    protected static readonly double[] InvalidFrequencies =
    {
        double.NaN,
        double.MinValue,
        double.NegativeInfinity,
        double.NegativeZero,
        0.0
    };
}