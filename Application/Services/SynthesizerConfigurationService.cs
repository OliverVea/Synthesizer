using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Abstractions.Models.Ids;

namespace Synthesizer.Application.Services;

public class SynthesizerConfigurationService : ISynthesizerConfigurationService
{
    private readonly ISynthesizerService _synthesizerService;
    private readonly IOscillatorService _oscillatorService;

    public SynthesizerConfigurationService(ISynthesizerService synthesizerService, IOscillatorService oscillatorService)
    {
        _synthesizerService = synthesizerService;
        _oscillatorService = oscillatorService;
    }

    public SynthesizerConfiguration GetSynthesizerConfiguration(SynthesizerId synthesizerId)
    {
        var synthesizerInformation = _synthesizerService.GetRequiredSynthesizer(synthesizerId);
        if (synthesizerInformation.OscillatorId == null)
            throw new InvalidOperationException(
                "Cannot create synthesizer configuration from synthesizer with no oscillator.");

        _oscillatorService.GetRequiredOscillator(synthesizerInformation.OscillatorId);

        return new SynthesizerConfiguration
        {
            SampleRate = synthesizerInformation.SampleRate,
            MasterVolume = synthesizerInformation.MasterVolume
        };
    }
}