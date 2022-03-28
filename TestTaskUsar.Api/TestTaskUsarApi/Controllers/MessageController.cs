using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskUsar.Domain.Core;
using TestTaskUsar.Domain.Core.DTO;
using TestTaskUsar.Services.Interfaces;

namespace TestTaskUsarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IEnumerable<MessageDTO>> Get()
        {
            return await _messageService.GetAll();
        }

        [HttpPost]
        public async Task<Message> Create(MessageForCreationDTO message)
        {
            return await _messageService.Create(message);
        }
    }
}
