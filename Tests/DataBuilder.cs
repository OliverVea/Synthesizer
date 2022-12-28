using AutoFixture;
using AutoFixture.Dsl;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Oscillators;
using Synthesizer.Abstractions.Models.Synthesizers;

namespace Tests.DataBuilders;

internal class DataBuilder
{
    private readonly Fixture _fixture = new();

    public IPostprocessComposer<OscillatorInformation> OscillatorInformation()
    {
        return _fixture.Build<OscillatorInformation>();
    }

    public IPostprocessComposer<CreateOscillatorRequest> CreateOscillatorRequest()
    {
        return _fixture.Build<CreateOscillatorRequest>();
    }

    public IPostprocessComposer<UpdateOscillatorRequest> UpdateOscillatorRequest(OscillatorId oscillatorId)
    {
        return _fixture.Build<UpdateOscillatorRequest>()
            .With(x => x.OscillatorId, oscillatorId);
    }

    public IPostprocessComposer<CreateSynthesizerRequest> CreateSynthesizerRequest()
    {
        return _fixture.Build<CreateSynthesizerRequest>();
    }

    public IPostprocessComposer<UpdateSynthesizerRequest> UpdateSynthesizerRequest(SynthesizerId id)
    {
        return _fixture.Build<UpdateSynthesizerRequest>().With(x => x.SynthesizerId, id);
    }

    public IPostprocessComposer<SynthesizerInformation> SynthesizerInformation()
    {
        return _fixture.Build<SynthesizerInformation>();
    }
}