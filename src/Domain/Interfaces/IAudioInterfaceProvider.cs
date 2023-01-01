namespace Synthesizer.Domain.Interfaces;

/// <summary>
/// Can be implemented to provide an audio interface to the application.
/// </summary>
public interface IAudioInterfaceProvider
{
    /// <summary>
    /// Lists audio interfaces for the audio interface provider.
    /// </summary>
    /// <returns>A list of audio interfaces</returns>
    IEnumerable<IAudioInterface> ListAudioInterfaces();
}