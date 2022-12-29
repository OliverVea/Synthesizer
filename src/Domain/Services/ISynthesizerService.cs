using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Synthesizers;

namespace Synthesizer.Domain.Services;

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
    /// <param name="synthesizerId">The synthesizer id</param>
    /// <returns>The information of the synthesizer. Null if no synthesizer could be found with the provided id.</returns>
    SynthesizerInformation? GetSynthesizer(SynthesizerId synthesizerId);

    /// <summary>
    ///     Gets the information about a specific synthesizer. Throws ArgumentException if the Synthesizer could not be found.
    /// </summary>
    /// <param name="synthesizerId">The synthesizer id</param>
    /// <returns>The information of the synthesizer.</returns>
    SynthesizerInformation GetRequiredSynthesizer(SynthesizerId synthesizerId);

    /// <summary>
    ///     Lists all available synthesizers.
    /// </summary>
    /// <returns></returns>
    SynthesizerInformation[] ListSynthesizers();

    /// <summary>
    ///     Deletes the synthesizer with the provided id.
    /// </summary>
    /// <param name="synthesizerId">Id of the synthesizer</param>
    void DeleteSynthesizer(SynthesizerId synthesizerId);

    /// <summary>
    ///     Updates a synthesizer based on the provided data.
    /// </summary>
    /// <param name="request"></param>
    void UpdateSynthesizer(UpdateSynthesizerRequest request);

    /// <summary>
    /// Used to set the Oscillator id of a Synthesizer.
    /// </summary>
    /// <param name="synthesizerId"></param>
    /// <param name="oscillatorId"></param>
    void SetOscillatorId(SynthesizerId synthesizerId, OscillatorId? oscillatorId);
}