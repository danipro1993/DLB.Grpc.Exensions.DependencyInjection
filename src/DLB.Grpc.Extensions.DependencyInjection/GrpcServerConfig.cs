using Grpc.Core;

namespace DLB.Grpc.Extensions.DependencyInjection
{
    public class GrpcServerConfig
    {
        public string Host { get; set;}

        public int Port { get; set; }

        public ServerCredentials Credentials { get; set; }
    }
}
