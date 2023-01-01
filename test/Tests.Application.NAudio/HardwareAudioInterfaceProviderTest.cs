using Application.NAudio;
using NUnit.Framework;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.NAudio;

public class HardwareAudioInterfaceProviderTest
{
    private IAudioInterfaceProvider _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new HardwareAudioInterfaceProvider();
    }

    [Test]
    public void HardwareAudioInterfaceProvider_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }
}