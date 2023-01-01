using Application.NAudio.Wrapping;
using NAudio.CoreAudioApi;
using Synthesizer.Domain.Interfaces;

namespace Application.NAudio;

public class HardwareAudioInterfaceProvider : IAudioInterfaceProvider
{
    private readonly IMMDeviceEnumerator _enumerator;

    public HardwareAudioInterfaceProvider(IMMDeviceEnumerator enumerator)
    {
        _enumerator = enumerator;
    }

    public IEnumerable<IAudioInterface> ListAudioInterfaces()
    {
        var audioEndPoints = _enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

        return audioEndPoints.Select(Map);
    }

    private static IAudioInterface Map(IMMDevice audioEndPoint)
    {
        return new HardwareAudioInterface();
    }
}