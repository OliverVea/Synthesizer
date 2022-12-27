using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Application.Services;

namespace Tests.Services;

public class SynthesizerConfigurationServiceTest : BaseUnitTest
{
    private ISynthesizerConfigurationService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new SynthesizerConfigurationService();
    }

    [Test]
    public void SynthesizerConfigurationService_WithInstanceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }
}