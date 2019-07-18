using Microsoft.Extensions.DependencyInjection;

namespace DLB.Grpc.Extensions.DependencyInjection.Builders
{
    public interface IGrpcServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
