using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
            try
            {
                _logger.LogInformation("Starting grpc server...");
                await _grpcServer.StartAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error initializing grpc server");
            }            
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping grpc server...");
            await _grpcServer.StopAsync(); 
        }
    }
}
