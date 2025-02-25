﻿using DevSummit2025.Model;
using DevSummit2025.Services.Contract;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DevSummit2025.Services.Implementation
{
    public class ServiceLogin(IConfiguration configuration) : IServiceLogin
    {
        private readonly HttpClient client = new HttpClient();
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
                var url = $"{urlBase}/companies/{res.companies[1].id}/select";//"https://wkeapipre.azure-api.net/a3factura/api/companies/27331/select"
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
