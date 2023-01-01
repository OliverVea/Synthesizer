using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application.Services;

public class AudioInterfaceService : IAudioInterfaceService
{
    private readonly IEnumerable<IAudioInterfaceProvider> _audioInterfaceProviders;

    public AudioInterfaceService(IEnumerable<IAudioInterfaceProvider> audioInterfaceProviders)
    {
        _audioInterfaceProviders = audioInterfaceProviders;
    }

    public IEnumerable<IAudioInterface> ListAudioInterfaces()
    {
        return _audioInterfaceProviders.SelectMany(x => x.ListAudioInterfaces()).ToArray();
    }
}