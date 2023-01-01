using System.Collections;

namespace Application.NAudio.Wrapping;

// ReSharper disable once InconsistentNaming
public interface IMMDeviceCollection : IEnumerable<IMMDevice>, IEnumerable
{
}