using Synthesizer.Domain.Entities;
using Synthesizer.Domain.Entities.Ids;
using Synthesizer.Domain.Services;

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

        var oscillatorInformation = _oscillatorService.GetRequiredOscillator(synthesizerInformation.OscillatorId);

        return new SynthesizerConfiguration(
            synthesizerInformation.SampleRate,
            synthesizerInformation.MasterVolume,
            oscillatorInformation.Waveform,
            oscillatorInformation.Frequency,
            oscillatorInformation.Amplitude);
    }
}