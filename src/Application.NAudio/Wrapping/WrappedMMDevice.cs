using NAudio.CoreAudioApi;

namespace Application.NAudio.Wrapping;

// ReSharper disable once InconsistentNaming
public class WrappedMMDevice : WrappedBase<MMDevice>, IMMDevice
{
    public WrappedMMDevice(MMDevice sourceObject) : base(sourceObject)
    {
    }
}