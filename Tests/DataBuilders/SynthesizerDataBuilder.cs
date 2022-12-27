using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models;
using Synthesizer.Abstractions.Models.Ids;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest()
    {
        return Fixture.Build<CreateSynthesizerRequest>();
    }

    public IPostprocessComposer<UpdateSynthesizerRequest> UpdateSynthesizerRequest(SynthesizerId id)
    {
        return Fixture.Build<UpdateSynthesizerRequest>().With(x => x.SynthesizerId, id);
    }

    public IPostprocessComposer<SynthesizerInformation> SynthesizerInformation()
    {
        return Fixture.Build<SynthesizerInformation>();
    }
}