using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace DevSummit2025.Services.Implementation
{
    public class ServiceCustomer(IConfiguration configuration, IServiceLogin serviceLogin) : IServiceCustomer
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string urlBase = configuration.GetValue<string>("Configuration:apimA3Factura");
        private readonly string apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");

        /// <summary>
        /// Ventajas de utilizar este get new, con este servicio obtenemos los datos default de un cliente
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetNew()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/customers/new";
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
        /// <summary>
        /// Creamos un cliente nuevo
        /// </summary>
        /// <returns></returns>
        public async Task Create()
        {
            var customerJson = await GetNew();
            var customer = JsonSerializer.Deserialize<CustomerDto>(customerJson);
            customer.name = "Juan teste";
            customer.businessName = "Juan SA";
            customer.vatNumber = "X0922441A";
            customer.vatNumberType = 3;

            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/customers";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            request.Headers.Add("Authorization", bearer);
            var json = JsonSerializer.Serialize(customer);
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

        }
        /// <summary>
        /// Obtenemos todos los clientes
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerDto>> GetAll()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/customers?pageNumber=1&pageSize=50&orderBy=&filter=(not%20isBlocked)%20and%20(not%20isObsolete)and%20(enabled%20eq%20true)";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            request.Headers.Add("Authorization", bearer);
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json= await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CustomerDto>>(json);
        }

        

        
    }
}
