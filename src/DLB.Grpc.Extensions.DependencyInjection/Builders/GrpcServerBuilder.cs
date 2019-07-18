using Grpc.Core;

namespace DLB.Grpc.Extensions.DependencyInjection
{
    public class GrpcServerBuilder
    {
        private string _host;
        private int _port;
        private ServerCredentials _credentials = ServerCredentials.Insecure;

        public static GrpcServerBuilder CreateServer() => new GrpcServerBuilder();

        public GrpcServerBuilder Host(string host)
        {
            _host = host;

            return this;
        }

        public GrpcServerBuilder Port(int port)
        {
            _port = port;

            return this;
        }

        public GrpcServerBuilder Crediantals(ServerCredentials credentials)
        {
            _credentials = credentials;

            return this;
        }

        public Server Build()
        {
            var server = new Server();

            server.Ports.Add(new ServerPort(_host, _port, _credentials));

            return server;
        }
    }
}
