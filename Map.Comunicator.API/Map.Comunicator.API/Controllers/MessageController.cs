using System.Threading.Tasks;
using Map.Comunicator.Domain.Interface;
using Map.Comunicator.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Map.Comunicator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService service;
        public MessageController(IMessageService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = service.GetMessages();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await service.AddMessage(value);
            return Ok(data);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MessageViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await service.UpdateMessage(id, value);
            return Ok(data);
        }
    }
}