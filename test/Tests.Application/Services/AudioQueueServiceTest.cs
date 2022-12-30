using Moq;
using NUnit.Framework;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Services;

namespace Tests.Application.Services;

public class AudioQueueServiceTest
{
    private IAudioQueueService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new AudioQueueService();
    }

    [Test]
    public void AudioQueueService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }
}