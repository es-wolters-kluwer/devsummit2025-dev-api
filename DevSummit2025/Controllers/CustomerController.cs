using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(IServiceCustomer service) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> Post()
        {
            await service.Create();
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            return Ok(await service.GetNew());
        }

        
    }
}
