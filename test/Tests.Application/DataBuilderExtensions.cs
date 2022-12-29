using AutoFixture.Dsl;
using AutoFixture.Kernel;
using Synthesizer.Domain.Entities;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Entities.Oscillators;
using Synthesizer.Domain.Entities.Synthesizers;

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

    public static IPostprocessComposer<SynthesizerConfiguration> SynthesizerConfiguration(this DataBuilder dataBuilder)
    {
        return dataBuilder.Fixture.Build<SynthesizerConfiguration>();
    }
}