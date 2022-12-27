using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models;

namespace Tests.DataBuilders;

internal partial class DataBuilder
{
    public IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest()
    {
        return Fixture.Build<CreateSynthesizerRequest>();
    }

    public IPostprocessComposer<SynthesizerInformation> SynthesizerInformation()
    {
        return Fixture.Build<SynthesizerInformation>();
    }
}