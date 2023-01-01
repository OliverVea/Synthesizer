using Synthesizer.Domain.Entities.Ids;

namespace Synthesizer.Domain.Exceptions;

/// <summary>
/// Exception when a oscillator could not be found with an id.
/// </summary>
public class NoOscillatorWithIdException : NoEntityWithIdException
{
    /// <summary>
    /// Constructor for exception when a oscillator could not be found with an id.
    /// </summary>
    /// <param name="oscillatorId">Id of the oscillator</param>
    /// <param name="parameterName">The parameter name of the id</param>
    public NoOscillatorWithIdException(
        OscillatorId oscillatorId,
        string parameterName) : base("oscillator", oscillatorId.ToString(), parameterName)
    {
    }
}