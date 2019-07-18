using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect_api_mq_service.MassTransit.Messages.Events;
using MassTransit;

namespace connect_api_mq_service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IBus _bus;

        public MessageService(IBus bus)
        {
            _bus = bus;
            
        }

        public async Task SendMessage(string message)
        {
            await _bus.Publish<MessageSentEvent>(
                new
                {
                    message = message
                });
        }
    }
}
