using System.Threading.Tasks;
using AdultMult.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace AdultMult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST: api/Update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            await _updateService.EchoAsync(update);
            return Ok();
        }
    }
}
