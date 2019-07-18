# DLB.Grpc.Exensions.DependencyInjection
Extensions method to use grpc in asp net core 2.2 with ServiceCollection

### Installation

DLB.Grpc.Exensions.DependencyInjection is a extensible library to use grpc in net core 2+. allows you to add in an easy way grpc server with many services.


### Usage
Then in Startup.cs file (or anything) add next lines to add new gprc server and declare services
```sh
using DLB.Grpc.Extensions.DependencyInjection.Extensions;
```

Finally in ServiceCollection class, we have avaible a extension method:
```sh
services.AddGrpc(config =>
            {
                config.Host = "127.0.0.1";
                config.Port = 50001;
                config.Credentials = ServerCredentials.Insecure;
            })
            .AddGrpcService<GreeterServiceImpl>(service => Greeter.BindService(service))
            .AddGrpcService<QueryServiceImpl>(svc => QueryService.BindService(svc));
```

Now, you already have a grpc server listening in 127.0.0.1:50001 with two services. In the cliente only need reference to proto files, generate cs (or other) files and use it
