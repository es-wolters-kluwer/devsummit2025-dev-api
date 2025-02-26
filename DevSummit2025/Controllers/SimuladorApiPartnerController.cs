using DevSummit2025.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimuladorApiPartnerController() : ControllerBase
    {
        /// <summary>
        ///  Recibira la informacion de los cambios de la entidad que se esta monitoreando
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostWebHook(WebHookChangesDto command)
        {
            return Ok(command);
        }

        /// <summary>
        /// Metodo que a3factura llama para comprobar que la api de webhook del partner es valida.
        /// </summary>
        /// <param name="echo"></param>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetCode([FromQuery] string echo)
        {
            return Content(echo, "text/plain");
        }
    }
}
