using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Synthesizers;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public static IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest()
    {
        return Fixture.Build<CreateSynthesizerRequest>();
    }

    public static IPostprocessComposer<UpdateSynthesizerRequest> UpdateSynthesizerRequest(SynthesizerId id)
    {
        return Fixture.Build<UpdateSynthesizerRequest>().With(x => x.SynthesizerId, id);
    }

    public static IPostprocessComposer<SynthesizerInformation> SynthesizerInformation()
    {
        return Fixture.Build<SynthesizerInformation>();
    }
}