using AutoFixture;
using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Services;

namespace Tests.Services;

public class SynthesizerServiceUnitTests : BaseUnitTest
{
    private static readonly object[] Waveforms =
    {
        Waveform.None,
        Waveform.Sawtooth,
        Waveform.Sine,
        Waveform.Square,
        Waveform.Triangle
    };

    private static readonly int[] SampleRates =
    {
        8000,   // Adequate for human speech but without sibilance. Used in telephone/walkie-talkie.
        11025,  // Used for lower-quality PCM, MPEG audio and for audio analysis of subwoofer bandpasses.
        16000,  // Used in most VoIP and VVoIP, extension of telephone narrowband.
        22050,  // Used for lower-quality PCM and MPEG audio and for audio analysis of low frequency energy.
        44100,  // Audio CD, most commonly used rate with MPEG-1 audio (VCD, SVCD, MP3). Covers the 20 kHz bandwidth.
        48000,  // Standard sampling rate used by professional digital video equipment, could reconstruct frequencies up to 22 kHz.
        88200,  // Used by some professional recording equipment when the destination is CD, such as mixers, EQs, compressors, reverb, crossovers and recording devices.
        96000,  // DVD-Audio, LPCM DVD tracks, Blu-ray audio tracks, HD DVD audio tracks.
        176400, // Used in HDCD recorders and other professional applications for CD production.
        192000, // Used with audio on professional video equipment. DVD-Audio, LPCM DVD tracks, Blu-ray audio tracks, HD DVD audio tracks.
        352800, // Digital eXtreme Definition. Used for recording and editing Super Audio CDs.
        374000  // Highest sample rate available for common software. Allows for precise peak detection.
    };

    private readonly Mock<ISynthesizerStore> _mockedStore;
    private readonly SynthesizerService _sut;

    public SynthesizerServiceUnitTests()
    {
        _mockedStore = new Mock<ISynthesizerStore>();
        _sut = new SynthesizerService(_mockedStore.Object);
    }

    [Test]
    public void SynthesizerService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }

    [Test]
    public void CreateSynthesizer_DefaultSynthesizer_AddsSynthesizerToStore()
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest().Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.IsAny<SynthesizerInformation>()));
    }

    [Test]
    public void CreateSynthesizer_NewSynthesizer_IdIsStoredAndReturned()
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest().Create();

        // Act
        var expected = _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.Is<SynthesizerId>(y => y == expected),
            It.IsAny<SynthesizerInformation>()));
    }

    [TestCaseSource(nameof(Waveforms))]
    public void CreateSynthesizer_SynthesizerWithWaveform_WaveformIsStored(Waveform waveform)
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.Waveform, waveform).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => y.Waveform == waveform)));
    }

    [TestCaseSource(nameof(SampleRates))]
    public void CreateSynthesizer_WithSamplingRate_SamplingRateIsStored(int sampleRate)
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.SampleRate, sampleRate).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => y.SampleRate == sampleRate)));
    }
}