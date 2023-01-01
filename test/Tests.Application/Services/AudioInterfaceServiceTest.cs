using Moq;
using NUnit.Framework;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.Services;

public class AudioInterfaceServiceTest
{
    private IAudioInterfaceService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new AudioInterfaceService();
    }

    [Test]
    public void AudioInterfaceService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }

    # region ListAudioInterfaces

    [Test]
    public void ListAudioInterfaces_WithNoProviders_GetsEmptyList()
    {
        // Arrange

        // Act
        var actual = _sut.ListAudioInterfaces();

        // Assert
        Assert.IsEmpty(actual);
    }

    # endregion
}