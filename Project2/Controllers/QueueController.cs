using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Dto;
using Project2.Model;
using Project2.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueRepository _queueRepository;
        public QueueController(IQueueRepository queueRepository)
        {
            _queueRepository = queueRepository;
        }
        [HttpPost("add")]
        public async Task<ActionResult> Add(MessageDto message) {
            Message mm = new Message()
            {
                Id = Guid.NewGuid(),
                Type = message.Type,
                Handled = false,
                JsonContent = message.JsonContent,
                AddAt = DateTime.Now
            };
            if (await _queueRepository.AddMessage(mm))
            {
                return OK("A new message was added successfully");
            }
            return BadRequest("Added wrong way");
        }

        private ActionResult OK(string v)
        {
            throw new NotImplementedException();
        }

        [HttpGet("handed/{messageId}")]
        public async Task<ActionResult>SetHandled(Guid messageId)
        {
            if(await _queueRepository.SetHandled(messageId))
            {
                return Ok("Message was set to handled state");
            }
            return BadRequest("Something was wrong");

        }
        [HttpGet("retrieve/email")]
        public async Task<ActionResult> GetUnhandledEmail()
        {
            var message = await _queueRepository.GetUnhandledEmailMessage();
            return Ok(message);
        }
        [HttpGet("retrieve/login")]
        public async Task<ActionResult> GetUnhandledLogin()
        {
            var message = await _queueRepository.GetUnhandledLoggingMessage();
            return Ok(message);
        }

    }
        
}
