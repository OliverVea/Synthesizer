using AutoFixture;
using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Application.Services;

namespace Tests.Services;

public class SynthesizerConfigurationServiceTest : BaseUnitTest
{
    private Mock<ISynthesizerService> _mockedSynthesizerService = null!;
    private Mock<IOscillatorService> _mockedOscillatorService = null!;
    private ISynthesizerConfigurationService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedSynthesizerService = new Mock<ISynthesizerService>();
        _mockedOscillatorService = new Mock<IOscillatorService>();

        _sut = new SynthesizerConfigurationService(
            _mockedSynthesizerService.Object,
            _mockedOscillatorService.Object);
    }

    [Test]
    public void SynthesizerConfigurationService_WithInstanceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }

    # region GetSynthesizerConfiguration

    [Test]
    public void GetSynthesizerConfiguration_WithSynthesizerId_GetsRequiredSynthesizerFromService()
    {
        // Arrange
        var synthesizerId = new SynthesizerId();

        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);

        // Act
        _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        _mockedSynthesizerService.Verify(x => x.GetRequiredSynthesizer(synthesizerId), Times.Once);
    }

    [Test]
    public void GetSynthesizerConfiguration_WithInvalidOscillatorId_ThrowsInvalidOperationException()
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation()
            .With(x => x.OscillatorId, (OscillatorId?)null).Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _sut.GetSynthesizerConfiguration(synthesizerId));
    }

    [Test]
    public void GetSynthesizerConfiguration_WithSynthesizerWithOscillator_GetsRequiredOscillatorFromService()
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var oscillatorId = new OscillatorId();

        var synthesizerInformation = DataBuilder.SynthesizerInformation()
            .With(x => x.OscillatorId, oscillatorId).Create();
        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);

        // Act
        _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        _mockedOscillatorService.Verify(x => x.GetRequiredOscillator(oscillatorId), Times.Once);
    }

    [TestCaseSource(nameof(SampleRates))]
    public void GetSynthesizerConfiguration_WithSampleRate_ConfigurationHasSampleRate(
        int sampleRate)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation()
            .With(x => x.SampleRate, sampleRate).Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.SampleRate, Is.EqualTo(sampleRate));
    }

    # endregion
}