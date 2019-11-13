using System.Threading.Tasks;
using Domain.Interface;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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

        /// <summary>
        /// Retuns all messages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var data = service.GetMessages();
            return Ok(data);
        }

        /// <summary>
        /// Create a new message
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a message based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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