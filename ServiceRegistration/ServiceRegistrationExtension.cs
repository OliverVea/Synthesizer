using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Application;
using Synthesizer.Application.Services;
using Synthesizer.Stores.Memory;

namespace Synthesizer.ServiceRegistration;

public static class ServiceRegistrationExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ISynthesizerService, SynthesizerService>();
    }

    public static void RegisterStores(this IServiceCollection services)
    {
        services.AddSingleton<ISynthesizerStore, SynthesizerStore>();
    }
}