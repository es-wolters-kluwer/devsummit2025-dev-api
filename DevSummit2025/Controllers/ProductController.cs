using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IServiceProduct service) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            await service.Create();
            return Ok();
        }
        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            return Ok(await service.GetNew());
        }
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await service.GetAll());
        }
        
        
    }
}
