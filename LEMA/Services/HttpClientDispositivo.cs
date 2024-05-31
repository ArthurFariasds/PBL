using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using PBL.Models;
using System.Security.Policy;
using System.Security.Cryptography.Xml;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace LEMA.Services
{
    public class HttpClientDispositivo
    {
        private HttpClient client;
        private const string IP_MAQUINA = "104.41.54.61";
        string url = $"http://{IP_MAQUINA}:4041";
        public HttpClientDispositivo()
        {
            client = ConfiguraHttpClient(url);
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Accept

            //Verificar a necessidade dos headers pra cada url declarada
            //_client.DefaultRequestHeaders.Add("Content-Type", "application/json"); // Content-Type
            _client.DefaultRequestHeaders.Add("fiware-service", "smart");
            _client.DefaultRequestHeaders.Add("fiware-servicepath", "/");
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public Task SalvarDispositivoAsync(int id)
        {
            var body = new
            {
                devices = new[] 
                {
                    new {
                        device_id = "temp" + id.ToString("D3"),
                        entity_name = "urn:ngsi-ld:Temp:" + id.ToString("D3"),
                        entity_type = "Temp",
                        protocol = "PDI-IoTA-UltraLight", 
                        transport = "MQTT",

                        commands = new[]
                        {
                            new { name = "on", type = "command" },
                            new { name = "off", type = "command" }
                        },

                        attributes = new[]
                        {
                            new { object_id = "s", name = "state", type = "Text" },
                            new { object_id = "t", name = "temperature", type = "Double" }
                        }
                    }
                }
            };

            return client.PostAsJsonAsync("iot/devices", body);
        }

        //O IP da URL é 1026 - url:1026/vs/registrations
        public Task RegistrarDispositivoAsync(int id)
        {
            var body = new
            {
                description = "Temp Commands",
                dataProvided = new
                {
                    entities = new[]
                    {
                        new { id = "urn:ngsi-ld:Temp:" + id.ToString("D3"), type = "Temp" }
                    },
                    attrs = new[]
                    {
                        "on", "off" 
                    }
                },
                provider = new
                {
                    http = new { url = $"http://{IP_MAQUINA}:4041" },
                    legacyForwarding = true,
                }
            };
            
            return client.PostAsJsonAsync("v2/registrations", body);
        }

        public RetornoDispositivo? ListarDispositivo()
        {
            return Task.Run(() => ListarDispositivoAsync()).Result;
        }


        private async Task<RetornoDispositivo?> ListarDispositivoAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url + "/iot/devices");
            return await response.Content.ReadFromJsonAsync<RetornoDispositivo>();
        }

        public Task DeletarDispositivo(string deviceId)
        {
            return client.DeleteAsync(url + "/iot/devices/" + deviceId);
        }

    }
}
