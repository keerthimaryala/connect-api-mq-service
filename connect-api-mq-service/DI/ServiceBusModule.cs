using MassTransit;
using MassTransit.ActiveMqTransport;
using Autofac;
using Pangea.Bedrock.Core.DI;
using Pangea.Bedrock.Core.Extensions;
using Microsoft.Extensions.Configuration;
using connect_api_mq_service.MassTransit.Consumers;
using GreenPipes.Introspection;

namespace connect_api_mq_service.DI
{
    public class ServiceBusModule : DependencyModule
    {
        protected override void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<SendMessageConsumer>();

            containerBuilder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();

                var brokerId = configuration.Lookup("ActiveMQ", "Id");

                // Save them in the aws Param store and retreive 
                var username = configuration.Lookup("ActiveMQ", "Username");

                var password = configuration.Lookup("ActiveMQ", "Password");

                var queue = configuration.Lookup("ActiveMQ", "Queue");

                var busControl = Bus.Factory.CreateUsingActiveMq(cfg =>
                {
                    var host = cfg.Host($"{brokerId}.mq.us-west-2.amazonaws.com", 61617, h =>
                    {
                        h.Username(username);
                        h.Password(password);

                        h.UseSsl();
                    });

                    cfg.ReceiveEndpoint(host, queue, ec =>
                    {
                        ec.Consumer<SendMessageConsumer>();
                    });
                });

                busControl.Start();

                return busControl;
            })
            .SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}
