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
        374000 // Highest sample rate available for common software. Allows for precise peak detection.
    };

    private static readonly double[] MasterVolumes =
    {
        0.0,
        0.001,
        0.5,
        0.999,
        1.0
    };

    private Mock<ISynthesizerStore> _mockedStore = null!;
    private SynthesizerService _sut = null!;

    [SetUp]
    public void SetupMocks()
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

    # region DeleteSynthesizer

    [Test]
    public void DeleteSynthesizer_WithSynthesizerId_UnderlyingMethodIsCalled()
    {
        // Arrange
        var id = SynthesizerId.NewId();

        // Act
        _sut.DeleteSynthesizer(id);

        // Assert
        _mockedStore.Verify(x => x.DeleteSynthesizer(id), Times.Once);
    }

    # endregion

    # region ListSynthesizers

    [Test]
    public void ListSynthesizers_WithNoSynthesizers_EmptyListIsReturned()
    {
        // Arrange

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        Assert.IsEmpty(actual);
    }

    [Test]
    public void ListSynthesizers_WithOneSynthesizer_IsListed()
    {
        // Arrange
        var synthesizers = new[]
        {
            DataBuilder.SynthesizerInformation().Create()
        };

        _mockedStore.Setup(x => x.ListSynthesizers()).Returns(synthesizers);

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        CollectionAssert.AreEqual(synthesizers, actual);
    }

    [Test]
    public void ListSynthesizers_WithMultipleSynthesizer_AreListed()
    {
        // Arrange
        var synthesizers = new[]
        {
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create()
        };

        _mockedStore.Setup(x => x.ListSynthesizers()).Returns(synthesizers);

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        CollectionAssert.AreEqual(synthesizers, actual);
    }

    # endregion

    #region GetSynthesizer

    [Test]
    public void GetSynthesizer_NoSynthesizers_NoneAreReturned()
    {
        // Arrange
        var id = SynthesizerId.NewId();

        // Act
        var actual = _sut.GetSynthesizer(id);

        // Assert
        Assert.IsNull(actual);
    }

    [Test]
    public void GetSynthesizer_ExistingSynthesizer_IsReturned()
    {
        // Arrange
        var id = SynthesizerId.NewId();
        var synthesizer = DataBuilder.SynthesizerInformation().Create();

        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizer);

        // Act
        var actual = _sut.GetSynthesizer(id);

        // Assert
        Assert.That(synthesizer, Is.EqualTo(actual));
    }

    #endregion

    #region CreateSynthesizer

    [Test]
    public void CreateSynthesizer_DefaultSynthesizer_AddsSynthesizerToStoreOnce()
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest().Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.IsAny<SynthesizerInformation>()), Times.Once);
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

    [TestCaseSource(nameof(MasterVolumes))]
    public void CreateSynthesizer_WithMasterVolume_MasterVolumeIsStored(double masterVolume)
    {
        // Arrange
        var tolerance = double.Max(masterVolume * 1e-9, 1e-12);
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.MasterVolume, masterVolume).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => Math.Abs(y.MasterVolume - masterVolume) < tolerance)));
    }

    [Test]
    public void CreateSynthesizer_WithNegativeMasterVolume_ShouldThrowValidationError()
    {
        // Arrange
        var masterVolume = -1.0;
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.MasterVolume, masterVolume).Create();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CreateSynthesizer(request));
    }

    [Test]
    public void CreateSynthesizer_WithDisplayName_DisplayNameIsStored()
    {
        // Arrange
        var displayName = "Display Name";
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.DisplayName, displayName).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => y.DisplayName == displayName)));
    }

    #endregion
}