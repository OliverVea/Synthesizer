using Moq;
using Application.NAudio;
using Application.NAudio.Wrapping;
using NAudio.CoreAudioApi;
using NUnit.Framework;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.NAudio;

public class HardwareAudioInterfaceProviderTest
{
    private Mock<IMMDeviceEnumerator> _mockedDeviceEnumerator = null!;
    private IAudioInterfaceProvider _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedDeviceEnumerator = new Mock<IMMDeviceEnumerator>();
        _sut = new HardwareAudioInterfaceProvider(_mockedDeviceEnumerator.Object);
    }

    [Test]
    public void HardwareAudioInterfaceProvider_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }

    # region ListAudioInterfaces

    [Test]
    public void ListAudioInterfaces__CallsUnderlyingMethod()
    {
        // Arrange
        MockEmptyEnumerator();

        // Act
        _sut.ListAudioInterfaces().ToArray();

        // Assert
        _mockedDeviceEnumerator.Verify(x => x.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active), Times.Once);
    }

    # endregion

    private void MockEmptyEnumerator()
    {
        var deviceCollection = MockEmptyDeviceCollection();
        MockEnumerator(deviceCollection);
    }

    private IMMDeviceCollection MockEmptyDeviceCollection()
    {
        var deviceCollection = new Mock<IMMDeviceCollection>();

        deviceCollection.Setup(x => x.GetEnumerator()).Returns(new List<IMMDevice>().GetEnumerator());

        return deviceCollection.Object;
    }

    private void MockEnumerator(IMMDeviceCollection deviceCollection)
    {
        _mockedDeviceEnumerator
            .Setup(x => x.EnumerateAudioEndPoints(It.IsAny<DataFlow>(), It.IsAny<DeviceState>()))
            .Returns(deviceCollection);
    }
}