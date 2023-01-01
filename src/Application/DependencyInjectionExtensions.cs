using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Application.Helpers;
using Synthesizer.Application.Helpers.WaveformGenerators;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application;

public static class ServiceRegistrationExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IOscillatorService, OscillatorService>();
        services.AddScoped<ISynthesizerService, SynthesizerService>();
        services.AddScoped<ISynthesizingService, SynthesizingService>();
        services.AddScoped<IAudioInterfaceService, AudioInterfaceService>();

        services.RegisterHelpers();
        services.RegisterWaveformGenerators();
    }

    private static void RegisterHelpers(this IServiceCollection services)
    {
        services.AddScoped<IWaveformHelper, WaveformHelper>();
    }

    private static void RegisterWaveformGenerators(this IServiceCollection services)
    {
        services.AddScoped<IWaveformGenerator, NoiseGenerator>();
        services.AddScoped<IWaveformGenerator, NoneGenerator>();
        services.AddScoped<IWaveformGenerator, SawtoothGenerator>();
        services.AddScoped<IWaveformGenerator, SineGenerator>();
        services.AddScoped<IWaveformGenerator, SquareGenerator>();
        services.AddScoped<IWaveformGenerator, TriangleGenerator>();
    }
}