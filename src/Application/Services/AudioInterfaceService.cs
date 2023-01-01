using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application.Services;

public class AudioInterfaceService : IAudioInterfaceService
{
    public List<IAudioInterface> ListAudioInterfaces()
    {
        return new List<IAudioInterface>();
    }
}