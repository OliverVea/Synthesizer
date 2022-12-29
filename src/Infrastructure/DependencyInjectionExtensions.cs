using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Application.Infrastructure;

namespace Synthesizer.Infrastructure;

public static class ServiceRegistrationExtension
{
    public static void RegisterStores(this IServiceCollection services)
    {
        services.AddSingleton<ISynthesizerStore, SynthesizerStore>();
    }
}