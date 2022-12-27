using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Services.Services;

namespace Tests.Services;

public class OscillatorServiceTest
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

    # region GetOscillator

    # endregion

    # region ListOscillators

    # endregion

    # region CreateOscillator

    # endregion

    # region DeleteOscillator

    # endregion

    # region UpdateOscillator

    # endregion
}