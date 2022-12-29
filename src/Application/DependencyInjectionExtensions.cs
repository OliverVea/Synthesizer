using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Application.Helpers;
using Synthesizer.Application.Helpers.WaveformGenerators;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Services;

namespace Synthesizer.Application;

public static class ServiceRegistrationExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<ISynthesizerService, SynthesizerService>();

        // Helpers
        services.AddScoped<IWaveformHelper, WaveformHelper>();

        // Waveform Generators
        services.AddScoped<IWaveformGenerator, NoiseGenerator>();
        services.AddScoped<IWaveformGenerator, NoneGenerator>();
        services.AddScoped<IWaveformGenerator, SawtoothGenerator>();
        services.AddScoped<IWaveformGenerator, SineGenerator>();
        services.AddScoped<IWaveformGenerator, SquareGenerator>();
        services.AddScoped<IWaveformGenerator, TriangleGenerator>();
    }
}