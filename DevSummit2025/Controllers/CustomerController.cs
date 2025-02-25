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

        private string urlBaseApi = "https://a3facturadev.a3software.com";
        private string bearer = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl9pZCI6ImU2OWNmNTU3LWFlNGMtNGIyYi1hMDE0LTI3MmUxNDkwNTUwOSIsImNsaWVudF9pZCI6IldLLkVTLkEzRkFDVFVSQSIsInNjb3BlIjoiV0suRVMuQTNGQUNUVVJBIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoicGF1bG8ucm9jaGFAZXh0ZXJuYWwud29sdGVyc2tsdXdlci5jb20iLCJsYW5nIjoiZXMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJwYXVsby5yb2NoYUBleHRlcm5hbC53b2x0ZXJza2x1d2VyLmNvbSIsInN1YiI6InBhdWxvLnJvY2hhQGV4dGVybmFsLndvbHRlcnNrbHV3ZXIuY29tIiwid2suZXMua2V5dXNlcmNvcnJlbGF0aW9uaWQiOiIxOTRmNTY5Mi0zZjg0LTQ0NWYtOGZiNS02YzAyODhiODc2MGQiLCJ1c3IiOiIxOTRmNTY5Mi0zZjg0LTQ0NWYtOGZiNS02YzAyODhiODc2MGQiLCJ3ay5lcy5yb2xpZCI6ImIwMDQ5ZTE2LWM1NDgtZWExMS1hNjAxLTAwMDNmZjFlNDFlMCIsIndrLmVzLmNsaWVudGlkIjoiMTI2MzgiLCJ3ay5lcy5yb2xlIjoiQWRtaW5pc3RyYXRvciIsIndrLmVzLmlkY2RhIjoiUFIwMDEiLCJ3ay5lcy5jb21wYW55VHlwZURlZmluZWQiOiJjb21wYW55VHlwZURlZmluZWQiLCJuYmYiOjE3NDA0ODYxMTcsImV4cCI6MTc0MDQ4OTcxNywiaXNzIjoiaHR0cHM6Ly9hM2ZhY3R1cmEud29sdGVyc2tsdXdlci5lcyIsImF1ZCI6Imh0dHBzOi8vYTNmYWN0dXJhLndvbHRlcnNrbHV3ZXIuZXMifQ.iVHH1SukgMQv4Wwo2RqbXua-gpHE2uSomvD--fd-C4_Qp20Un6I9s1GfXJR_4SvdEUpV-LatQreU1Cvpkae3HQ";
        private readonly HttpClient client = new HttpClient();



        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
            //string url = $"{urlBaseApi}/services/api/customers?pageNumber=1&pageSize=50&orderBy=&filter=(not%20isBlocked)%20and%20(not%20isObsolete)and%20(enabled%20eq%20true)";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            //request.Headers.Add("Authorization", bearer);
            //HttpResponseMessage response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();

            //return Ok(responseBody);
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            return Ok(await service.GetNew());
            //string url = $"{urlBaseApi}/services/api/customers/new";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            //request.Headers.Add("Authorization", bearer);
            //HttpResponseMessage response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //return Ok(responseBody);
        }

        [HttpPost()]
        public async Task<IActionResult> Post()
        {
            await service.Create();
            //string url = $"{urlBaseApi}/services/api/customers";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            //request.Headers.Add("Accept", "text/plain");
            //request.Headers.Add("api-version", "2.0");
            //request.Headers.Add("Authorization", bearer);
            //var json = JsonSerializer.Serialize(model);
            //request.Content = new StringContent(json);
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //HttpResponseMessage response = await client.SendAsync(request);
            //string responseBody = await response.Content.ReadAsStringAsync();
            return Ok();
        }
    }
}
