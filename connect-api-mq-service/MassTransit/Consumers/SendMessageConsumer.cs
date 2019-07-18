using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect_api_mq_service.MassTransit.Messages.Commands;
using connect_api_mq_service.MassTransit.Messages.Events;
using MassTransit;

namespace connect_api_mq_service.MassTransit.Consumers
{
    public class SendMessageConsumer : IConsumer<MessageSentEvent>
    {
        public async Task Consume(ConsumeContext<MessageSentEvent> context)
        {
            await Console.Out.WriteLineAsync($"Received Message : {context.Message.message}");           
        }
    }
}
