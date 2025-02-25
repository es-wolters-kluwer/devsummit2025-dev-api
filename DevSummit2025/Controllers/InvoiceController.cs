using Microsoft.AspNetCore.Mvc;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),        
            })
            .ToArray();
        }

        [HttpPost()]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
