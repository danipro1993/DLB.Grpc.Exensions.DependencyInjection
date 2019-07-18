using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLB.Grpc.Extensions.DependencyInjection
{
    public class GrpcServer
    {
        private Server _server;

        public GrpcServer(GrpcServerConfig serverConfig, IEnumerable<ServerServiceDefinition> services)
        {
            _server = new Server();
            _server.Ports.Add(new ServerPort(serverConfig.Host, serverConfig.Port, serverConfig.Credentials));

            BindServices(services);
        }

        public Task StartAsync()
        {
            _server.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            return _server.KillAsync();
        }

        private void BindServices(IEnumerable<ServerServiceDefinition> services)
        {
            foreach (var s in services)
            {
                _server.Services.Add(s);
            }            
        }
    }
}
