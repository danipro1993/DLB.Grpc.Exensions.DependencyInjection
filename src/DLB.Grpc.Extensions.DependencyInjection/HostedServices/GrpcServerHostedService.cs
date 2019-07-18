using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DLB.Grpc.Extensions.DependencyInjection.HostedServices
{
    public class GrpcServerHostedService : IHostedService
    {
        private readonly GrpcServer _grpcServer;
        private readonly ILogger<GrpcServerHostedService> _logger;

        public GrpcServerHostedService(GrpcServer grpcServer, 
                                       ILogger<GrpcServerHostedService> logger)
        {
            _grpcServer = grpcServer ?? throw new ArgumentNullException(nameof(grpcServer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting grpc server...");
            await _grpcServer.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping grpc server...");
            await _grpcServer.StopAsync(); 
        }
    }
}
