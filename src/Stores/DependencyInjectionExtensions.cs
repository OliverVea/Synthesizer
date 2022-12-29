using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Stores.Memory;

public static class ServiceRegistrationExtension
{
    public static void RegisterStores(this IServiceCollection services)
    {
        services.AddSingleton<ISynthesizerStore, SynthesizerStore>();
    }
}