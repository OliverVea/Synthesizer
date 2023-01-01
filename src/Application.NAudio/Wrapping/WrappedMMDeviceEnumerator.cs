using NAudio.CoreAudioApi;

namespace Application.NAudio.Wrapping;

// ReSharper disable once InconsistentNaming
public class WrappedMMDeviceEnumerator : WrappedBase<MMDeviceEnumerator>, IMMDeviceEnumerator
{
    public WrappedMMDeviceEnumerator(MMDeviceEnumerator sourceObject) : base(sourceObject)
    {
    }

    public IMMDeviceCollection EnumerateAudioEndPoints(DataFlow dataFlow, DeviceState deviceState)
    {
        var deviceCollection = SourceObject.EnumerateAudioEndPoints(dataFlow, deviceState);
        return new WrappedMMDeviceCollection(deviceCollection);
    }
}