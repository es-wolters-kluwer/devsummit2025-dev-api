using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebHookController(IConfiguration configuration, IServiceWebHook service) : ControllerBase
    {
        private readonly HttpClient client = new HttpClient();


        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery]string idcda)
        {
            return Ok(await service.GetAllLogs(idcda));

            //var url = configuration.GetValue<string>("Configuration:apimWebhook")+ $"/GetLog?idcda={idcda}";
            //var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("Api-Version", "2.0");            
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //var res = JsonSerializer.Deserialize<UserRsDto>(responseBody);

            

            //return Ok(responseBody);
        }

        [HttpGet("GetActiveWebHook")]
        public async Task<IActionResult> GetActiveWebHookAsync()
        {
            return Ok(await service.GetAllActive());

            //string beaererToken = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl9pZCI6IjhmZjc4MWZhLTQ0MDctNDdkYS05ZTUyLTQ0OWE0M2EwZjMzYyIsImNsaWVudF9pZCI6IldLLkVTLkEzRkFDVFVSQSIsInNjb3BlIjoiV0suRVMuQTNGQUNUVVJBIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoicGF1bG8ucm9jaGFAd29sdGVyc2tsdXdlci5jb20iLCJsYW5nIjoiZXMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJwYXVsby5yb2NoYUB3b2x0ZXJza2x1d2VyLmNvbSIsInN1YiI6InBhdWxvLnJvY2hhQHdvbHRlcnNrbHV3ZXIuY29tIiwid2suZXMua2V5dXNlcmNvcnJlbGF0aW9uaWQiOiIxMzljZTNhNi00N2QzLTQ0MzAtYWM4ZC03OTk5M2E1Y2Y0ODgiLCJ1c3IiOiIxMzljZTNhNi00N2QzLTQ0MzAtYWM4ZC03OTk5M2E1Y2Y0ODgiLCJ3ay5lcy5yb2xpZCI6Ijg1YWI5MWFhLTcwYTYtZWExMS05YjA1LTI4MTg3ODNjNWE4YiIsIndrLmVzLmNsaWVudGlkIjoiMjI0MDgiLCJ3ay5lcy5yb2xlIjoiQWRtaW5pc3RyYXRvciIsIndrLmVzLmlkY2RhIjoiUE8wMTAiLCJ3ay5lcy5jb21wYW55VHlwZURlZmluZWQiOiJjb21wYW55VHlwZURlZmluZWQiLCJuYmYiOjE3NDA1MTE1MDUsImV4cCI6MTc0MDUxNTEwNSwiaXNzIjoiaHR0cHM6Ly9hM2ZhY3R1cmEud29sdGVyc2tsdXdlci5lcyIsImF1ZCI6Imh0dHBzOi8vYTNmYWN0dXJhLndvbHRlcnNrbHV3ZXIuZXMifQ.ItiZjY8JFzHFlBG7be7EGjJ1b72FdIpf7cIHfo8AgeJIKfOJZgLva1jhLHWZ1MMz-r8-j4jFlTwfgHvUt3-aWA";
            //var url = configuration.GetValue<string>("Configuration:apimA3Factura") + "/webhooks";
            //var apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("api-version", "2.0");
            //request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            //request.Headers.Add("Authorization", beaererToken);
            //HttpResponseMessage response = await client.SendAsync(request);
            //string responseBody = await response.Content.ReadAsStringAsync();
            //return Ok(responseBody);
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync()
        {
            return Ok(await service.Subscribe());
            //string beaererToken = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl9pZCI6IjhmZjc4MWZhLTQ0MDctNDdkYS05ZTUyLTQ0OWE0M2EwZjMzYyIsImNsaWVudF9pZCI6IldLLkVTLkEzRkFDVFVSQSIsInNjb3BlIjoiV0suRVMuQTNGQUNUVVJBIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoicGF1bG8ucm9jaGFAd29sdGVyc2tsdXdlci5jb20iLCJsYW5nIjoiZXMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJwYXVsby5yb2NoYUB3b2x0ZXJza2x1d2VyLmNvbSIsInN1YiI6InBhdWxvLnJvY2hhQHdvbHRlcnNrbHV3ZXIuY29tIiwid2suZXMua2V5dXNlcmNvcnJlbGF0aW9uaWQiOiIxMzljZTNhNi00N2QzLTQ0MzAtYWM4ZC03OTk5M2E1Y2Y0ODgiLCJ1c3IiOiIxMzljZTNhNi00N2QzLTQ0MzAtYWM4ZC03OTk5M2E1Y2Y0ODgiLCJ3ay5lcy5yb2xpZCI6Ijg1YWI5MWFhLTcwYTYtZWExMS05YjA1LTI4MTg3ODNjNWE4YiIsIndrLmVzLmNsaWVudGlkIjoiMjI0MDgiLCJ3ay5lcy5yb2xlIjoiQWRtaW5pc3RyYXRvciIsIndrLmVzLmlkY2RhIjoiUE8wMTAiLCJ3ay5lcy5jb21wYW55VHlwZURlZmluZWQiOiJjb21wYW55VHlwZURlZmluZWQiLCJuYmYiOjE3NDA1MTE1MDUsImV4cCI6MTc0MDUxNTEwNSwiaXNzIjoiaHR0cHM6Ly9hM2ZhY3R1cmEud29sdGVyc2tsdXdlci5lcyIsImF1ZCI6Imh0dHBzOi8vYTNmYWN0dXJhLndvbHRlcnNrbHV3ZXIuZXMifQ.ItiZjY8JFzHFlBG7be7EGjJ1b72FdIpf7cIHfo8AgeJIKfOJZgLva1jhLHWZ1MMz-r8-j4jFlTwfgHvUt3-aWA";
            //var url = configuration.GetValue<string>("Configuration:apimA3Factura")+ "/webhooks";

            //var urlWebHook = configuration.GetValue<string>("Configuration:apimWebhook");
            //var apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("api-version", "2.0");
            //request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            //request.Headers.Add("Authorization", beaererToken);

            //var body = new
            //{
            //    uri= urlWebHook, 
            //    entity = "Product", 
            //    action = "Updated",  
            //    secret = "12345678978978979787978988978978979878979",  
            //    isPaused = false,  
            //    applicationName = "test", 
            //    description = "test"
            // };


            //request.Content = new StringContent(JsonSerializer.Serialize(body));
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //HttpResponseMessage response = await client.SendAsync(request);
            
            //string responseBody = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //{
            //    return Ok(responseBody);
            //}
            //else
            //{
            //    return BadRequest($"Status error {response.StatusCode} {responseBody}");
        }
    }
}
