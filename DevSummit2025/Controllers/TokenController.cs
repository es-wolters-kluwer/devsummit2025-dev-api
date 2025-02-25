using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController(IServiceLogin service) : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await service.GetToken());
        }       
    }
}
