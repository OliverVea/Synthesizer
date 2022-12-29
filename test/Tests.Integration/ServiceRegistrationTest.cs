using NUnit.Framework;

namespace Tests.Integration;

public class ServiceRegistrationTest : BaseIntegrationTest
{
    [Test]
    public void GetService_OnAllRegisteredServices_ReturnsValidService()
    {
        Assert.IsNotEmpty(Services);
        foreach (var serviceDescriptor in Services)
        {
            var service = GetService(serviceDescriptor.ServiceType);
            Assert.NotNull(service);
        }
    }
}