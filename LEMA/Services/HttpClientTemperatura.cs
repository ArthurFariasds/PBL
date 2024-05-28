using PBL.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using LEMA.Models;

namespace LEMA.Services
{
    public class HttpClientTemperatura
    {
        private HttpClient client;
        private const string IP_MAQUINA = "104.41.54.61";
        string url = $"http://{IP_MAQUINA}:8666";
        public HttpClientTemperatura()
        {
            client = ConfiguraHttpClient(url);
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Accept

            _client.DefaultRequestHeaders.Add("fiware-service", "smart");
            _client.DefaultRequestHeaders.Add("fiware-servicepath", "/");
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public RetornoTemperatura? GetUltimaTemperatura()
        {
            return Task.Run(() => GetUltimaTemperaturaAsync()).Result;
        }

        private async Task<RetornoTemperatura?> GetUltimaTemperaturaAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url + "/STH/v1/contextEntities/type/Temp/id/urn:ngsi-ld:Temp:001/attributes/temperature?lastN=1");
            return await response.Content.ReadFromJsonAsync<RetornoTemperatura>();
        }
    }
}
