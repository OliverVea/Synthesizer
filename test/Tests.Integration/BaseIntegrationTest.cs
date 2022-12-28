using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Synthesizer.Application;
using Synthesizer.Stores.Memory;

namespace Tests.Integration;

public abstract class BaseIntegrationTest
{
    private readonly IServiceCollection _services = new ServiceCollection();
    private IServiceProvider _serviceProvider = null!;
    protected IEnumerable<ServiceDescriptor> Services => _services.AsEnumerable();

    [SetUp]
    public void SetupServices()
    {
        _services.RegisterServices();
        _services.RegisterStores();
        _serviceProvider = _services.BuildServiceProvider();
    }

    protected TService GetService<TService>() where TService : notnull
    {
        return _serviceProvider.GetRequiredService<TService>();
    }

    protected object GetService(Type t)
    {
        return _serviceProvider.GetRequiredService(t);
    }
}