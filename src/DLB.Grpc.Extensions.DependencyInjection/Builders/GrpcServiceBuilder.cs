using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DLB.Grpc.Extensions.DependencyInjection.Builders
{
    public class GrpcServiceBuilder : IGrpcServiceBuilder
    {
        public GrpcServiceBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }
    }
}
