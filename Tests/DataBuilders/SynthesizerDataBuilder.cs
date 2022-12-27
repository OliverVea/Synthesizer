using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models;

namespace Tests.DataBuilders;

partial class DataBuilder
{
    public IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest()
    {
        return Fixture.Build<CreateSynthesizerRequest>();
    }
}