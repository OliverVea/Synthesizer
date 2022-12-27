using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;

namespace Synthesizer.Application.Services;

public class SynthesizerConfigurationService : ISynthesizerConfigurationService
{
    private readonly ISynthesizerService _synthesizerService;

    public SynthesizerConfigurationService(ISynthesizerService synthesizerService)
    {
        _synthesizerService = synthesizerService;
    }

    public void GetSynthesizerConfiguration(SynthesizerId synthesizerId)
    {
        _synthesizerService.GetRequiredSynthesizer(synthesizerId);
    }
}