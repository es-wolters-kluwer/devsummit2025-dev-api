using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
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
        public async Task<IActionResult> PostAsync(ProductDto model)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://a3facturadev.a3software.com/services/api/products");
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Authorization",
                "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl9pZCI6ImZkN2RiMDhlLWU2ZDUtNGY4Mi1iZGEwLTZkMWI5ZTljMzNkZCIsImNsaWVudF9pZCI6IldLLkVTLkEzRkFDVFVSQSIsInNjb3BlIjoiV0suRVMuQTNGQUNUVVJBIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoicGF1bG8ucm9jaGFAZXh0ZXJuYWwud29sdGVyc2tsdXdlci5jb20iLCJsYW5nIjoiZXMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJwYXVsby5yb2NoYUBleHRlcm5hbC53b2x0ZXJza2x1d2VyLmNvbSIsInN1YiI6InBhdWxvLnJvY2hhQGV4dGVybmFsLndvbHRlcnNrbHV3ZXIuY29tIiwid2suZXMua2V5dXNlcmNvcnJlbGF0aW9uaWQiOiIxOTRmNTY5Mi0zZjg0LTQ0NWYtOGZiNS02YzAyODhiODc2MGQiLCJ1c3IiOiIxOTRmNTY5Mi0zZjg0LTQ0NWYtOGZiNS02YzAyODhiODc2MGQiLCJ3ay5lcy5yb2xpZCI6ImIwMDQ5ZTE2LWM1NDgtZWExMS1hNjAxLTAwMDNmZjFlNDFlMCIsIndrLmVzLmNsaWVudGlkIjoiMTI2MzgiLCJ3ay5lcy5yb2xlIjoiQWRtaW5pc3RyYXRvciIsIndrLmVzLmlkY2RhIjoiUFIwMDEiLCJ3ay5lcy5jb21wYW55VHlwZURlZmluZWQiOiJjb21wYW55VHlwZURlZmluZWQiLCJuYmYiOjE3NDA0NzYwMjUsImV4cCI6MTc0MDQ3OTYyNSwiaXNzIjoiaHR0cHM6Ly9hM2ZhY3R1cmEud29sdGVyc2tsdXdlci5lcyIsImF1ZCI6Imh0dHBzOi8vYTNmYWN0dXJhLndvbHRlcnNrbHV3ZXIuZXMifQ.sf1Qx7VOUqJ_GNzqJVf3os0LI80WB8wsy7bwlenuI4RXEb5SoYKRVXi9ZGcsZTY_yct29pxdc_YqiK8sM6cpUQ");

            var json = JsonSerializer.Serialize(model);

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);            
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }
    }
}
