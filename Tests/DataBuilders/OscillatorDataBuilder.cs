using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models.Oscillators;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public IPostprocessComposer<OscillatorInformation> OscillatorInformation()
    {
        return Fixture.Build<OscillatorInformation>();
    }

    public IPostprocessComposer<CreateOscillatorRequest> CreateOscillatorRequest()
    {
        return Fixture.Build<CreateOscillatorRequest>();
    }
}