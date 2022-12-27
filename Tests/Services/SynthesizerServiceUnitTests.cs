using AutoFixture;
using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Services;

namespace Tests.Services;

public class SynthesizerServiceUnitTests : BaseUnitTest
{
    private readonly SynthesizerService _sut;
    private readonly Mock<ISynthesizerStore> _mockedStore;

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
        8000,
        11025
    };
}