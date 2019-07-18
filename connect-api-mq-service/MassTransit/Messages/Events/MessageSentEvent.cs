using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connect_api_mq_service.MassTransit.Messages.Events
{
    public class MessageSentEvent
    {
        public string message { get; set; }
    }
}
