namespace Synthesizer.Domain.Interfaces;

/// <summary>
/// Service for managing and using audio queues.
/// </summary>
public interface IAudioInterfaceService
{
    /// <summary>
    /// Lists available audio interfaces.
    /// </summary>
    /// <returns>Available audio interfaces.</returns>
    List<IAudioInterface> ListAudioInterfaces();
}