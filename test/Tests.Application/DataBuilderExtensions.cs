using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;
using Synthesizer.Abstractions.Models.Synthesizers;

namespace Tests.Application;

public static class DataBuilderExtensions
{
    public static IPostprocessComposer<OscillatorInformation> OscillatorInformation(this DataBuilder dataBuilder)
    {
        return dataBuilder.Fixture.Build<OscillatorInformation>();
    }

    public static IPostprocessComposer<CreateOscillatorRequest> CreateOscillatorRequest(this DataBuilder dataBuilder)
    {
        return dataBuilder.Fixture.Build<CreateOscillatorRequest>();
    }

    public static IPostprocessComposer<UpdateOscillatorRequest> UpdateOscillatorRequest(this DataBuilder dataBuilder,
        OscillatorId oscillatorId)
    {
        return dataBuilder.Fixture.Build<UpdateOscillatorRequest>()
            .With(x => x.OscillatorId, oscillatorId);
    }

    public static IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest(this DataBuilder dataBuilder)
    {
        return dataBuilder.Fixture.Build<CreateSynthesizerRequest>();
    }

    public static IPostprocessComposer<UpdateSynthesizerRequest> UpdateSynthesizerRequest(this DataBuilder dataBuilder,
        SynthesizerId id)
    {
        return dataBuilder.Fixture.Build<UpdateSynthesizerRequest>().With(x => x.SynthesizerId, id);
    }

    public static IPostprocessComposer<SynthesizerInformation> SynthesizerInformation(this DataBuilder dataBuilder)
    {
        return dataBuilder.Fixture.Build<SynthesizerInformation>();
    }
}