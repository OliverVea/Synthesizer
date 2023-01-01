﻿using Moq;
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
        var audioInterfaceProviders = Array.Empty<IAudioInterfaceProvider>();
        _sut = new AudioInterfaceService(audioInterfaceProviders);
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

    [Test]
    public void ListAudioInterfaces_WithProviderWithInterface_GetsInterface()
    {
        // Arrange
        var audioInterfaces = new[]
        {
            new Mock<IAudioInterface>().Object
        };

        var audioInterfaceProvider = new Mock<IAudioInterfaceProvider>();
        audioInterfaceProvider.Setup(x => x.ListAudioInterfaces()).Returns(audioInterfaces);
        var audioInterfaceProviders = new List<IAudioInterfaceProvider> { audioInterfaceProvider.Object };

        _sut = new AudioInterfaceService(audioInterfaceProviders);

        // Act
        var actual = _sut.ListAudioInterfaces();

        // Assert
        CollectionAssert.AreEqual(audioInterfaces, actual);
    }

    # endregion
}