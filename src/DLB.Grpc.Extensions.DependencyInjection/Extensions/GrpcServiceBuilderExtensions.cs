using DLB.Grpc.Extensions.DependencyInjection.Builders;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DLB.Grpc.Extensions.DependencyInjection.Extensions
{
    public static class GrpcServiceBuilderExtensions
    {
        public static IGrpcServiceBuilder AddGrpcService<TService>(this IGrpcServiceBuilder builder,
                                                                   Func<TService, ServerServiceDefinition> buildService) where TService : class
        {
            builder.Services.AddTransient<TService>();
            builder.Services.AddSingleton<ServerServiceDefinition>(sp =>
            {
                var s = sp.GetService<TService>();
                var definition = buildService(s);

                return definition;
            });            

            return builder;
        }
    }
}
