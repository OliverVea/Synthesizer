using Synthesizer.Abstractions.Models;

namespace Synthesizer.Abstractions.Interfaces;

/// <summary>
///     Service used to manage and use Synthesizers.
/// </summary>
public interface ISynthesizerService
{
    /// <summary>
    ///     Creates a new synthesizer, based on the data in the request.
    /// </summary>
    /// <param name="request">Initial configuration of the synthesizer.</param>
    /// <returns>Id of the newly created synthesizer.</returns>
    SynthesizerId CreateSynthesizer(CreateSynthesizerRequest request);

    /// <summary>
    ///     Gets the information about a specific synthesizer.
    /// </summary>
    /// <param name="id">The synthesizer id</param>
    /// <returns>The information of the synthesizer. Null if no synthesizer could be found with the provided id.</returns>
    SynthesizerInformation? GetSynthesizer(SynthesizerId id);

    /// <summary>
    ///     Lists all available synthesizers.
    /// </summary>
    /// <returns></returns>
    SynthesizerInformation[] ListSynthesizers();

    /// <summary>
    ///     Deletes the synthesizer with the provided id.
    /// </summary>
    /// <param name="id">Id of the synthesizer</param>
    void DeleteSynthesizer(SynthesizerId id);

    /// <summary>
    ///     Updates a synthesizer based on the provided data.
    /// </summary>
    /// <param name="request"></param>
    void UpdateSynthesizer(UpdateSynthesizerRequest request);

    /// <summary>
    ///     Synthesizes audio samples from the synthesizer.
    /// </summary>
    /// <param name="id">Id of the synthesizer to generate samples from.</param>
    /// <param name="sampleCount">Number of samples to generate.</param>
    /// <returns>Object containing audio samples generated from the synthesizer.</returns>
    AudioSample GetNextSamples(SynthesizerId id, int sampleCount);
}