using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connect_api_mq_service.Services
{
    public interface IMessageService
    {
        Task SendMessage(string message);
    }
}
