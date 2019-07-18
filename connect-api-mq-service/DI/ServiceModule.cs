using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using connect_api_mq_service.Services;
using Pangea.Bedrock.Core.DI;

namespace connect_api_mq_service.DI
{ 
    [DependsOn(typeof(ServiceBusModule))]
    public class ServiceModule : DependencyModule
    {
        protected override void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MessageService>().As<IMessageService>();
        }
    }
}
