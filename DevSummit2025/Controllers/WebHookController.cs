using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebHookController(IServiceWebHook service) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            return Ok(await service.Subscribe());
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery]string idcda)
        {
            return Ok(await service.GetAllLogs(idcda));        
        }

        [HttpGet("GetActiveWebHook")]
        public async Task<IActionResult> GetActiveWebHookAsync()
        {
            return Ok(await service.GetAllActive());
        }

        
    }
}
