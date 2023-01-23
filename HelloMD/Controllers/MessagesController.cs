using HelloMD.Dtos;
using HelloMD.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HelloMD.Controllers
{
    [Route("/api/messages")]
    [Produces("application/json")]
    public class MessagesController : ControllerBase
    {
        private IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // POST: MessagesController/Create
        [HttpPost]
        public IActionResult Create([FromBody] MessageDto msg)
        {
            var msgDto = _messageService.CreateMessage(msg);
            return Ok(msgDto);
        }


    }
}
