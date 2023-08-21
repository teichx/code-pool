using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Configuration;

namespace CodePool.Sharp.Extension;

public class ServiceBinderWithServiceResolutionFromServices(IServiceCollection services) : ServiceBinder
{
    private readonly IServiceCollection services = services;

    public override IList<object> GetMetadata(MethodInfo method, Type contractType, Type serviceType)
    {
        var resolvedServiceType = serviceType.IsInterface
            ? services.SingleOrDefault(x => x.ServiceType == serviceType)?.ImplementationType ?? serviceType
            : serviceType;

        return base.GetMetadata(method, contractType, resolvedServiceType);
    }
}
