using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace DevSummit2025.Services.Implementation
{
    public class ServiceSaleInvoice(IConfiguration configuration, IServiceLogin serviceLogin, IServiceCustomer serviceCustomer, IServiceProduct serviceProduct) : IServiceSaleInvoice
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string urlBase = configuration.GetValue<string>("Configuration:apimA3Factura");
        private readonly string apiSubscriptionKey = configuration.GetValue<string>("Configuration:apiSubscriptionKey");

        public async Task<SaleInvoiceDtoRs> GetNew()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/saleInvoices/new";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            request.Headers.Add("Authorization", bearer);
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SaleInvoiceDtoRs>(json);
        }
        public async Task<InvoiceLineDto> GetNewLine()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/saleInvoices/newLine";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,pt;q=0.8");
            request.Headers.Add("Authorization", bearer);
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<InvoiceLineDto>(json);
        }
        
        public async Task Create()
        {
            var invoice = await GetNew();                       // Get New de la factura, para obtener los datos por defecto
            var lineProduct = await GetNewLine();               // Get New de la linea de factura, para obtener los datos por defecto
            var productList = await serviceProduct.GetAll();    // Buscamos todos los productos, para obtener el id del producto creado previamente
            lineProduct.productId = productList[1].id;

            invoice.lines = new object[] { lineProduct };

            var customerList = await serviceCustomer.GetAll();  // Buscamos todos clientes, para obtener el id del cliente creado previamente e insertamos en la factura
            invoice.customerId = customerList[0].id;
            invoice.name = customerList[0].name;
            invoice.documentNumber = "1233";


            string bearer = await serviceLogin.GetToken();      // Obtenemos el token, para hacer la peticion de creacion de la factura
            string url = $"{urlBase}/saleInvoices";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("api-version", "2.0");
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubscriptionKey);
            request.Headers.Add("Authorization", bearer);
            var json = JsonSerializer.Serialize(invoice);
            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

        }
        public async Task<string> GetAll()
        {
            string bearer = await serviceLogin.GetToken();
            string url = $"{urlBase}/saleInvoices?pageNumber=1&pageSize=50&orderBy=date%20Desc&filter=";
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

        

        

        
    }
}
