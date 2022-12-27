using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Application.Services;

namespace Tests.Services;

public class SynthesizerConfigurationServiceTest : BaseUnitTest
{
    private Mock<ISynthesizerService> _mockedSynthesizerService = null!;
    private ISynthesizerConfigurationService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedSynthesizerService = new Mock<ISynthesizerService>();
        _sut = new SynthesizerConfigurationService(_mockedSynthesizerService.Object);
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

        // Act
        _sut.GetSynthesizerConfiguration(synthesizerId);

        // Assert
        _mockedSynthesizerService.Verify(x => x.GetRequiredSynthesizer(synthesizerId), Times.Once);
    }

    # endregion
}