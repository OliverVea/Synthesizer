using AutoFixture;
using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;
using Synthesizer.Services.Services;

namespace Tests.Services;

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

    # region DeleteOscillator

    # endregion

    # region UpdateOscillator

    # endregion
}