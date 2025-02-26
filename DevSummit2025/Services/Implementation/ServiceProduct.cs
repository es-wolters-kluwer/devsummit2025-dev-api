using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace DevSummit2025.Services.Implementation
{
    public class ServiceProduct(IConfiguration configuration, IServiceLogin serviceLogin) : IServiceProduct
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string urlBase = configuration.GetValue<string>("Configuration:apimA3Factura");
        private readonly string apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");
        
        

        public async Task<string> GetNew()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/products/new";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            request.Headers.Add("Authorization", bearer);
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task Create()
        {
            var productJson = await GetNew();
            var product = JsonSerializer.Deserialize<ProductDto>(productJson);
            product.description = "Arroz";
            product.salePrice = 12;

            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/products";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            request.Headers.Add("Authorization", bearer);
            var json = JsonSerializer.Serialize(product);
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

        }
        public async Task<List<ProductGetAllDto>> GetAll()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/products?pageNumber=1&pageSize=50&orderBy=code&filter=(not%20isBlocked)";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            request.Headers.Add("Authorization", bearer);
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductGetAllDto>>(json);

        }
    }
}
