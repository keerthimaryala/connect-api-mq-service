using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect_api_mq_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace connect_api_mq_service.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class StatusController : ControllerBase
    {
        private IMessageService _service;

        public StatusController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/status")]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "Running"
            });
        }

        [HttpGet]
        [Route("api/message")]
        public IActionResult Send()
        {
            _service.SendMessage("Test Message");
            return Ok();
        }
    }
}