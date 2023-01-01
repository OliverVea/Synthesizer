using Synthesizer.Domain.Entities.Ids;

namespace Synthesizer.Domain.Exceptions;

/// <summary>
/// Exception when a synthesizer could not be found with an id.
/// </summary>
public class NoSynthesizerWithIdException : NoEntityWithIdException
{
    /// <summary>
    /// Constructor for exception when a synthesizer could not be found with an id.
    /// </summary>
    /// <param name="synthesizerId">Id of the synthesizer</param>
    /// <param name="parameterName">The parameter name of the id</param>
    public NoSynthesizerWithIdException(
        SynthesizerId synthesizerId,
        string parameterName) : base("synthesizer", synthesizerId.ToString(), parameterName)
    {
    }
}