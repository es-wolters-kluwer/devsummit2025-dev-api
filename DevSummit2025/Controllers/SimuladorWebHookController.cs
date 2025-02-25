using DevSummit2025.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimuladorWebHookController() : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostWebHook(WebHookChangesDto command)
        {
            return Ok(command);
        }

        [HttpGet()]
        public IActionResult GetCode([FromQuery] string echo)
        {
            return Content(echo, "text/plain");
        }
    }
}
