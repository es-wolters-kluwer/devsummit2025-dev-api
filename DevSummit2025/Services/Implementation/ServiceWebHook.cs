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

        /// <summary>
        /// Este servicio se encarga de suscribirse a un webhook, para recibir notificaciones de eventos en la API
        /// </summary>
        /// <returns></returns>
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
                uri = urlWebHook,   // url de la api del tercero
                secret = "12345678978978979787978988978978979878979",  // secreto para la api del tercero
                entity = "Product", // entidad a la que se suscribe
                action = "Updated", // accion a la que se suscribe (Created, Updated, Deleted)
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

        /// <summary>
        /// Este servicio se encarga de obtener todos los webhooks activos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Este servicio se encarga de obtener todos los logs de nuestro simulador de webhook
        /// </summary>
        /// <param name="idcda"></param>
        /// <returns></returns>
        public async Task<string> GetAllLogs(string idcda)
        {
            var url = configuration.GetValue<string>("Configuration:apimWebhook") + $"/GetLog?idcda={idcda}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Api-Version", "2.0");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();            
        }

        
    }
}
