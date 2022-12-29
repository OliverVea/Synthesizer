using AutoFixture;
using Moq;
using NUnit.Framework;
using Synthesizer.Application.Helpers;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Services;

namespace Tests.Application.Services;

public class SynthesizingServiceTest : BaseUnitTest
{
    private Mock<IWaveformHelper> _mockedWaveformHelper = null!;
    private ISynthesizingService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedWaveformHelper = new Mock<IWaveformHelper>();
        _sut = new SynthesizingService(_mockedWaveformHelper.Object);
    }

    [Test]
    public void SynthesizingService_WithInstanceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }

    # region GenerateSamples

    [Test]
    public void GenerateSamples_WithValidInput_CallsGenerateMethodWithCorrectArguments()
    {
        // Arrange
        const double offset = 1.0;
        const int sampleCount = 32;
        var synthesizerConfiguration = DataBuilder.SynthesizerConfiguration().Create();

        // Act
        var actual = _sut.GenerateSamples(sampleCount, synthesizerConfiguration, offset);

        // Assert
        Assert.That(actual.AudioSamples.Length, Is.EqualTo(sampleCount));
        _mockedWaveformHelper.Verify(x => x.GenerateSamples(
            actual.AudioSamples,
            synthesizerConfiguration.SampleRate,
            synthesizerConfiguration.Amplitude,
            synthesizerConfiguration.Frequency,
            synthesizerConfiguration.Waveform,
            offset));
    }

    # endregion
}