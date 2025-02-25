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


            //var request = new HttpRequestMessage(HttpMethod.Post, "https://a3facturadev.a3software.com/Services/api/users/login");
            //request.Headers.Add("Api-Version", "2.0");
            //request.Headers.Add("Ocp-Apim-Subscription-Key", "2kxwf5rb7ffb65dd5");
            //var content = new StringContent("{\"mail\":\"paulo.rocha@external.wolterskluwer.com\",\"password\":\"Lseis@1992\"}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //var res = JsonSerializer.Deserialize<UserRsDto>(responseBody);

            //if (res?.companies?.Count() > 0)
            //{
            //    string url = $"https://a3facturadev.a3software.com/services/api/companies/{res.companies[0].id}/select";
            //    HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Post, url);
            //    request.Content = new StringContent($"\"{res.refreshToken}\"");
            //    request1.Headers.Add("Accept", "application/json");
            //    request1.Headers.Add("api-version", "2.0");
            //    request1.Headers.Add("Authorization", $"{res.token}");

            //    HttpResponseMessage response1 = await client.SendAsync(request1);
            //    response.EnsureSuccessStatusCode();
            //    responseBody = await response1.Content.ReadAsStringAsync();
            //}

            //return Ok(responseBody);
        }       
    }
}
