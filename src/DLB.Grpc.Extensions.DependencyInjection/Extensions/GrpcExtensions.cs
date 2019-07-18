using DLB.Grpc.Extensions.DependencyInjection.Builders;
using DLB.Grpc.Extensions.DependencyInjection.HostedServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DLB.Grpc.Extensions.DependencyInjection.Extensions
{
    public static class GrpcExtensions
    {
        public static IGrpcServiceBuilder AddGrpc(this IServiceCollection services, Action<GrpcServerConfig> configServer)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var opts = new GrpcServerConfig();

            configServer?.Invoke(opts);

            services.AddSingleton(opts);
            services.AddSingleton<GrpcServer>();           
            services.AddHostedService<GrpcServerHostedService>();

            var serviceBuilder = new GrpcServiceBuilder(services);

            return serviceBuilder;
        }        
    }
}
