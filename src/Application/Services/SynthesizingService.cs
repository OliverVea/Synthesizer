using Synthesizer.Application.Helpers;
using Synthesizer.Domain.Entities;
using Synthesizer.Domain.Services;

namespace Synthesizer.Application.Services;

public class SynthesizingService : ISynthesizingService
{
    private readonly IWaveformHelper _waveformHelper;

    public SynthesizingService(IWaveformHelper waveformHelper)
    {
        _waveformHelper = waveformHelper;
    }

    public AudioSample GenerateSamples(int sampleCount,
        SynthesizerConfiguration synthesizerConfiguration,
        double offset)
    {
        var sampleBuffer = new double[sampleCount];

        _waveformHelper.GenerateSamples(
            sampleBuffer,
            synthesizerConfiguration.SampleRate,
            synthesizerConfiguration.Amplitude,
            synthesizerConfiguration.Frequency,
            synthesizerConfiguration.Waveform,
            offset);

        return new AudioSample
        {
            AudioSamples = sampleBuffer
        };
    }
}