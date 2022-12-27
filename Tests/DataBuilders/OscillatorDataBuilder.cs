using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public IPostprocessComposer<OscillatorInformation> OscillatorInformation()
    {
        return Fixture.Build<OscillatorInformation>();
    }
}