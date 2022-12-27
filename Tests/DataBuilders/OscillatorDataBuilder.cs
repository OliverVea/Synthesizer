using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public static IPostprocessComposer<OscillatorInformation> OscillatorInformation()
    {
        return Fixture.Build<OscillatorInformation>();
    }

    public static IPostprocessComposer<CreateOscillatorRequest> CreateOscillatorRequest()
    {
        return Fixture.Build<CreateOscillatorRequest>();
    }

    public static IPostprocessComposer<UpdateOscillatorRequest> UpdateOscillatorRequest(OscillatorId oscillatorId)
    {
        return Fixture.Build<UpdateOscillatorRequest>()
            .With(x => x.OscillatorId, oscillatorId);
    }
}