using Synthesizer.Domain.Interfaces;

namespace Application.NAudio;

public class HardwareAudioInterfaceProvider : IAudioInterfaceProvider
{
    public IEnumerable<IAudioInterface> ListAudioInterfaces()
    {
        throw new NotImplementedException();
    }
}