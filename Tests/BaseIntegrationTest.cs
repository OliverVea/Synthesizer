using Microsoft.Extensions.DependencyInjection;
using Synthesizer.ServiceRegistration;

namespace Tests;

public abstract class BaseIntegrationTest
{
    private IServiceProvider _serviceProvider = null!;
    
    [SetUp]
    public void SetupServices()
    {
        var services = new ServiceCollection();
        services.RegisterServices();
        services.RegisterStores();
        _serviceProvider = services.BuildServiceProvider();
    }

    protected TService GetService<TService>() where TService : notnull
    {
        return _serviceProvider.GetRequiredService<TService>();
    }
}