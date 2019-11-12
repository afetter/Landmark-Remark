using System.Threading.Tasks;
using Map.Comunicator.Domain.Interface;
using Map.Comunicator.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Map.Comunicator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService _service)
        {
            service = _service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await service.Login(value);

            if (data.HasError)
            {
                return BadRequest(data);
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await service.AddUser(value);
            
            if (data.HasError)
            {
                return BadRequest(data);
            }

            return Ok(data);
        }
    }
}