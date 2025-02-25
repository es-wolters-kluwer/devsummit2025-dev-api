using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Services.Implementation
{
    public class ServiceWebHook(IConfiguration configuration, IServiceLogin serviceLogin) : IServiceWebHook
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string urlBase = configuration.GetValue<string>("Configuration:apimA3Factura");
        private readonly string apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");

        public async Task<string> GetAllActive()
        {
            string beaererToken = await serviceLogin.GetToken();
            var url = urlBase + "/webhooks";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            request.Headers.Add("Authorization", beaererToken);
            HttpResponseMessage response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();            
        }

        public async Task<string> GetAllLogs(string idcda)
        {
            var url = configuration.GetValue<string>("Configuration:apimWebhook") + $"/GetLog?idcda={idcda}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Api-Version", "2.0");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();            
        }

        public async Task<bool> Subscribe()
        {
            string beaererToken = await serviceLogin.GetToken(); 
            var url = urlBase + "/webhooks";

            var urlWebHook = configuration.GetValue<string>("Configuration:apimWebhook");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            request.Headers.Add("Authorization", beaererToken);

            var body = new
            {
                uri = urlWebHook,
                entity = "Product",
                action = "Updated",
                secret = "12345678978978979787978988978978979878979",
                isPaused = false,
                applicationName = "test",
                description = "test"
            };


            request.Content = new StringContent(JsonSerializer.Serialize(body));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
            
        }

        public async Task<string> GetToken()
        {
            string token = string.Empty;
            var urlBase = configuration.GetValue<string>("Configuration:apimA3Factura");
            var urlLogin = urlBase + "/users/login";
            var apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");

            var request = new HttpRequestMessage(HttpMethod.Post, urlLogin);
            request.Headers.Add("Api-Version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            var content = new StringContent("{\"mail\":\"paulo.rocha@wolterskluwer.com\",\"password\":\"Lseis@1992\"}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var res = JsonSerializer.Deserialize<UserRsDto>(responseBody);
            token = res != null? res.token: token;
            
            if (res?.companies?.Count() > 0)
            {
                var url = $"{urlBase}/companies/{res.companies[0].id}/select";//"https://wkeapipre.azure-api.net/a3factura/api/companies/27331/select"
                HttpRequestMessage requestCompany = new HttpRequestMessage(HttpMethod.Post, url);

                requestCompany.Headers.Add("Accept", "application/json");
                requestCompany.Headers.Add("api-version", "2.0");
                requestCompany.Headers.Add("Authorization", res.token);
                requestCompany.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);

                requestCompany.Content = new StringContent($"\"{res.refreshToken}\"");
                requestCompany.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage responseCompany = await client.SendAsync(requestCompany);
                responseCompany.EnsureSuccessStatusCode();
                responseBody = await responseCompany.Content.ReadAsStringAsync();
                var resultCompany = JsonSerializer.Deserialize<SelectCompanyResultDto>(responseBody);
                token = resultCompany!=null ? resultCompany.token: token;
            }
            return token;
        }

        
    }
}
