using System.Collections;
using NAudio.CoreAudioApi;

namespace Application.NAudio.Wrapping;

// ReSharper disable once InconsistentNaming
public class WrappedMMDeviceCollection : WrappedBase<MMDeviceCollection>, IMMDeviceCollection
{
    private readonly IEnumerable<IMMDevice> _content;

    public WrappedMMDeviceCollection(MMDeviceCollection sourceObject) : base(sourceObject)
    {
        _content = sourceObject.Select(x => new WrappedMMDevice(x));
    }

    public IEnumerator<IMMDevice> GetEnumerator()
    {
        return _content.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}