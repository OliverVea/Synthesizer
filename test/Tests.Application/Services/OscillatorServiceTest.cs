using AutoFixture;
using Moq;
using NUnit.Framework;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;
using Synthesizer.Application.Services;

namespace Tests.Application.Services;

public class OscillatorServiceTest : BaseUnitTest
{
    private Mock<IOscillatorStore> _mockedStore = null!;
    private IOscillatorService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedStore = new Mock<IOscillatorStore>();
        _sut = new OscillatorService(_mockedStore.Object);
    }

    [Test]
    public void OscillatorService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }

    # region CreateOscillator

    [Test]
    public void CreateOscillator_DefaultOscillator_CallsUnderlyingMethod()
    {
        // Arrange
        var request = DataBuilder.CreateOscillatorRequest().Create();

        // Act
        _sut.CreateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(
            It.IsAny<OscillatorId>(),
            It.IsAny<OscillatorInformation>()), Times.Once);
    }

    [Test]
    public void CreateOscillator_DefaultOscillator_IdIsReturned()
    {
        // Arrange
        var request = DataBuilder.CreateOscillatorRequest().Create();

        // Act
        var oscillatorId = _sut.CreateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(oscillatorId,
            It.IsAny<OscillatorInformation>()), Times.Once);
    }

    [TestCaseSource(nameof(Waveforms))]
    public void CreateOscillator_WithWaveform_WaveformIsStored(Waveform waveform)
    {
        // Arrange
        var request = DataBuilder.CreateOscillatorRequest()
            .With(x => x.Waveform, waveform).Create();

        // Act
        _sut.CreateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(
            It.IsAny<OscillatorId>(),
            It.Is<OscillatorInformation>(y => y.Waveform == waveform)), Times.Once);
    }

    [TestCaseSource(nameof(Frequencies))]
    public void CreateOscillator_WithFrequency_FrequencyIsStored(double frequency)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance(frequency);
        var request = DataBuilder.CreateOscillatorRequest()
            .With(x => x.Frequency, frequency).Create();

        // Act
        _sut.CreateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(
            It.IsAny<OscillatorId>(),
            It.Is<OscillatorInformation>(y => Math.Abs(y.Frequency - frequency) < tolerance)), Times.Once);
    }

    [TestCaseSource(nameof(InvalidFrequencies))]
    public void CreateOscillator_WithInvalidFrequency_ThrowsArgumentException(double invalidFrequency)
    {
        // Arrange
        var request = DataBuilder.CreateOscillatorRequest()
            .With(x => x.Frequency, invalidFrequency).Create();

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.CreateOscillator(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.Frequency)));
    }

    [TestCaseSource(nameof(Amplitudes))]
    public void CreateOscillator_WithAmplitude_AmplitudeIsStored(double amplitude)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance(amplitude);
        var request = DataBuilder.CreateOscillatorRequest()
            .With(x => x.Amplitude, amplitude).Create();

        // Act
        _sut.CreateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(
            It.IsAny<OscillatorId>(),
            It.Is<OscillatorInformation>(y => Math.Abs(y.Amplitude - amplitude) < tolerance)), Times.Once);
    }

    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void CreateOscillator_WithInvalidAmplitude_ThrowsArgumentException(double invalidAmplitude)
    {
        // Arrange
        var request = DataBuilder.CreateOscillatorRequest()
            .With(x => x.Amplitude, invalidAmplitude).Create();

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.CreateOscillator(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.Amplitude)));
    }

    # endregion

    # region ListOscillators

    [Test]
    public void ListOscillators__GetsOscillatorsFromStore()
    {
        // Arrange

        // Act
        _sut.ListOscillators();

        // Assert
        _mockedStore.Verify(x => x.ListOscillators(), Times.Once);
    }

    [Test]
    public void ListOscillators_WithNoOscillators_ReturnsOscillatorsFromStore()
    {
        // Arrange
        var oscillators = Array.Empty<OscillatorInformation>();

        _mockedStore.Setup(x => x.ListOscillators()).Returns(oscillators);

        // Act
        var actual = _sut.ListOscillators();

        // Assert
        CollectionAssert.AreEqual(oscillators, actual);
    }

    [Test]
    public void ListOscillators_WithManyOscillators_ReturnsOscillatorsFromStore()
    {
        // Arrange
        var oscillators = new[]
        {
            DataBuilder.OscillatorInformation().Create(),
            DataBuilder.OscillatorInformation().Create(),
            DataBuilder.OscillatorInformation().Create(),
            DataBuilder.OscillatorInformation().Create()
        };

        _mockedStore.Setup(x => x.ListOscillators()).Returns(oscillators);

        // Act
        var actual = _sut.ListOscillators();

        // Assert
        CollectionAssert.AreEqual(oscillators, actual);
    }

    # endregion

    # region GetOscillator

    [Test]
    public void GetOscillator__GetsOscillatorFromStore()
    {
        // Arrange
        var id = new OscillatorId();

        // Act
        _sut.GetOscillator(id);

        // Assert
        _mockedStore.Verify(x => x.GetOscillator(id), Times.Once);
    }

    [Test]
    public void GetOscillator__StoredValueIsReturned()
    {
        // Arrange
        var id = new OscillatorId();

        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();
        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(oscillatorInformation);

        // Act
        var actual = _sut.GetOscillator(id);

        // Assert
        Assert.That(actual, Is.EqualTo(oscillatorInformation));
    }

    # endregion

    # region GetRequiredOscillator

    [Test]
    public void GetRequiredOscillator_WithInvalidOscillatorId_ThrowsArgumentException()
    {
        // Arrange
        var oscillatorId = new OscillatorId();

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.GetRequiredOscillator(oscillatorId));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(oscillatorId)));
    }

    [Test]
    public void GetRequiredOscillator_WithValidOscillatorId_ReturnsOscillator()
    {
        // Arrange
        var oscillatorId = new OscillatorId();

        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();
        _mockedStore.Setup(x => x.GetOscillator(oscillatorId)).Returns(oscillatorInformation);

        // Act
        var actual = _sut.GetRequiredOscillator(oscillatorId);

        // Assert
        Assert.That(actual, Is.EqualTo(oscillatorInformation));
    }

    # endregion

    # region DeleteOscillator

    [Test]
    public void DeleteOscillator__DeletesOscillatorFromStore()
    {
        // Arrange
        var id = new OscillatorId();

        // Act
        _sut.DeleteOscillator(id);

        // Assert
        _mockedStore.Verify(x => x.DeleteOscillator(id), Times.Once);
    }

    # endregion

    # region UpdateOscillator

    [Test]
    public void UpdateOscillator_WithNoChanges_UpdatesStoredEntity()
    {
        // Arrange
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id).Create();

        var oscillatorInformation = DataBuilder.OscillatorInformation().Create();
        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(oscillatorInformation);

        // Act
        _sut.UpdateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(id, It.IsAny<OscillatorInformation>()), Times.Once);
    }

    [Test]
    public void UpdateOscillator_WithInvalidId_ThrowsArgumentException()
    {
        // Arrange
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns((OscillatorInformation?)null);

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.UpdateOscillator(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request.OscillatorId)));
    }

    [TestCaseSource(nameof(Amplitudes))]
    public void UpdateOscillator_NewAmplitude_UpdatesStoredOscillator(double amplitude)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance(amplitude);
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id)
            .With(x => x.Amplitude, amplitude).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(new OscillatorInformation());

        // Act
        _sut.UpdateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(id,
            It.Is<OscillatorInformation>(y => Math.Abs(y.Amplitude - amplitude) < tolerance)));
    }

    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void UpdateOscillator_InvalidAmplitude_ThrowsArgumentException(double invalidAmplitude)
    {
        // Arrange
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id)
            .With(x => x.Amplitude, invalidAmplitude).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(new OscillatorInformation());

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.UpdateOscillator(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.Amplitude)));
    }

    [TestCaseSource(nameof(Frequencies))]
    public void UpdateOscillator_NewFrequency_UpdatesStoredOscillator(double frequency)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance(frequency);
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id)
            .With(x => x.Frequency, frequency).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(new OscillatorInformation());

        // Act
        _sut.UpdateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(id,
            It.Is<OscillatorInformation>(y => Math.Abs(y.Frequency - frequency) < tolerance)));
    }

    [TestCaseSource(nameof(InvalidFrequencies))]
    public void UpdateOscillator_InvalidFrequency_ThrowsArgumentException(double invalidFrequency)
    {
        // Arrange
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id)
            .With(x => x.Frequency, invalidFrequency).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(new OscillatorInformation());

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.UpdateOscillator(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.Frequency)));
    }

    [TestCaseSource(nameof(Waveforms))]
    public void UpdateOscillator_NewWaveform_UpdatesStoredOscillator(Waveform waveform)
    {
        // Arrange
        var id = new OscillatorId();
        var request = DataBuilder.UpdateOscillatorRequest(id)
            .With(x => x.Waveform, waveform).Create();

        _mockedStore.Setup(x => x.GetOscillator(id)).Returns(new OscillatorInformation());

        // Act
        _sut.UpdateOscillator(request);

        // Assert
        _mockedStore.Verify(x => x.SetOscillator(id,
            It.Is<OscillatorInformation>(y => y.Waveform == waveform)));
    }

    # endregion
}