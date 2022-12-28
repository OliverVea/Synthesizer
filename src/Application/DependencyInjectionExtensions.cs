using Microsoft.Extensions.DependencyInjection;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Interfaces;

namespace Synthesizer.Application;

public static class ServiceRegistrationExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ISynthesizerService, SynthesizerService>();
    }
}