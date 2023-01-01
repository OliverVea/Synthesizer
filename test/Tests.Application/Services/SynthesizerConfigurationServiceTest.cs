using AutoFixture;
using Moq;
using NUnit.Framework;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Oscillators;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.Services;

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
        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

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
        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        _mockedOscillatorService.Verify(x => x.GetRequiredOscillator(oscillatorId), Times.Once);
    }

    [TestCaseSource(nameof(SampleRates))]
    [TestCaseSource(nameof(InvalidSampleRates))]
    public void GetSynthesizerConfiguration_WithSampleRate_ConfigurationHasSampleRate(int sampleRate)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation()
            .With(x => x.SampleRate, sampleRate).Create();
        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.SampleRate, Is.EqualTo(sampleRate));
    }

    [TestCaseSource(nameof(Amplitudes))]
    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void GetSynthesizerConfiguration_WithMasterVolume_ConfigurationHasMasterVolume(double masterVolume)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation()
            .With(x => x.MasterVolume, masterVolume).Create();
        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.MasterVolume, Is.EqualTo(masterVolume));
    }

    [TestCaseSource(nameof(Waveforms))]
    public void GetSynthesizerConfiguration_WithWaveform_ConfigurationHasWaveform(Waveform waveform)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        var oscillatorInformation = DataBuilder.OscillatorInformation().With(x => x.Waveform, waveform).Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.Waveform, Is.EqualTo(waveform));
    }

    [TestCaseSource(nameof(Frequencies))]
    [TestCaseSource(nameof(InvalidFrequencies))]
    public void GetSynthesizerConfiguration_WithFrequency_ConfigurationHasFrequency(double frequency)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        var oscillatorInformation = DataBuilder.OscillatorInformation().With(x => x.Frequency, frequency).Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.Frequency, Is.EqualTo(frequency));
    }

    [TestCaseSource(nameof(Amplitudes))]
    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void GetSynthesizerConfiguration_WithAmplitude_ConfigurationHasAmplitude(double amplitude)
    {
        // Arrange
        var synthesizerId = new SynthesizerId();
        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        var oscillatorInformation = DataBuilder.OscillatorInformation().With(x => x.Amplitude, amplitude).Create();

        _mockedSynthesizerService.Setup(x => x.GetRequiredSynthesizer(synthesizerId))
            .Returns(synthesizerInformation);
        _mockedOscillatorService.Setup(x => x.GetRequiredOscillator(It.IsAny<OscillatorId>()))
            .Returns(oscillatorInformation);

        // Act
        var synthesizerConfiguration = _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        Assert.That(synthesizerConfiguration.Amplitude, Is.EqualTo(amplitude));
    }

    # endregion
}