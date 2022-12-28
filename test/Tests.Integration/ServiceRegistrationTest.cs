using NUnit.Framework;

namespace Tests.Integration;

public class ServiceRegistrationTest : BaseIntegrationTest
{
    [Test]
    public void Test()
    {
        Assert.IsNotEmpty(Services);
        foreach (var serviceDescriptor in Services)
        {
            var service = GetService(serviceDescriptor.ServiceType);
            Assert.NotNull(service);
        }
    }
}