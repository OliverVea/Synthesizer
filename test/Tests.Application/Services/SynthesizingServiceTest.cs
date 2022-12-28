using AutoFixture;
using NUnit.Framework;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.Services;

public class SynthesizingServiceTest : BaseUnitTest
{
    private ISynthesizingService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new SynthesizingService();
    }

    [Test]
    public void SynthesizingService_WithInstanceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }

    # region GenerateSamples

    [Test]
    public void GenerateSamples_WithValidInput_ReturnsSampleArrayWithSize()
    {
        // Arrange
        var synthesizerConfiguration = DataBuilder.SynthesizerConfiguration().Create();
        const int sampleCount = 32;
        const double offset = 0.0;

        // Act
        var actual = _sut.GenerateSamples(synthesizerConfiguration, sampleCount, offset);

        // Assert
        Assert.That(actual.AudioSamples.Length, Is.EqualTo(sampleCount));
    }

    # endregion
}