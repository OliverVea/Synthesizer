using NAudio.CoreAudioApi;

namespace Application.NAudio.Wrapping;

// ReSharper disable once InconsistentNaming
public interface IMMDeviceEnumerator
{
    IMMDeviceCollection EnumerateAudioEndPoints(DataFlow render, DeviceState active);
}