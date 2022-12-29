using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Synthesizers;

namespace Synthesizer.Domain.Interfaces;

/// <summary>
///     Store used for storing Synthesizers for ISynthesizerService.
/// </summary>
public interface ISynthesizerStore
{
    /// <summary>
    ///     Lists all available synthesizers.
    /// </summary>
    /// <returns></returns>
    public SynthesizerInformation[] ListSynthesizers();

    /// <summary>
    ///     Gets a specific synthesizer by id.
    /// </summary>
    /// <param name="id">The synthesizer id</param>
    /// <returns></returns>
    public SynthesizerInformation? GetSynthesizer(SynthesizerId id);

    /// <summary>
    ///     Creates or updates a Synthesizer with the provided configuration and id.
    /// </summary>
    /// <param name="id">The synthesizer id</param>
    /// <param name="synthesizerInformation">The synthesizer configuration</param>
    public void SetSynthesizer(SynthesizerId id, SynthesizerInformation synthesizerInformation);

    /// <summary>
    ///     Deletes the specified Synthesizer permanently.
    /// </summary>
    /// <param name="id">The synthesizer id</param>
    public void DeleteSynthesizer(SynthesizerId id);
}