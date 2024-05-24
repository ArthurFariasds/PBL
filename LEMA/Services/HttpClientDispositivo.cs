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

namespace LEMA.Services
{
    public class HttpClientDispositivo
    {
        private HttpClient client;
        public HttpClientDispositivo(string uri = "http://{{url}}:4041")
        {
            client = ConfiguraHttpClient(uri);
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Accept

            //Verificar a necessidade dos headers pra cada url declarada
            _client.DefaultRequestHeaders.Add("Content-Type", "application/json"); // Content-Type
            _client.DefaultRequestHeaders.Add("fiware-service", "smart");
            _client.DefaultRequestHeaders.Add("fiware-servicepath", "/");
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public Task SalvarDispositivoAsync(DispositivoViewModel dispositivo)
        {
            //exemplo de como fazer o body: -- sujeito à alterações, não testado
            var body = new
            {
                devices = new[] // verificar json do body, [] = lista, {} = objeto
                {
                    new {
                        //tem que adicionar os 3 digitos - temp001, Temp:001
                        device_id = "temp" + dispositivo.Id,
                        entity_name = "urn:ngsi-ld:Temp:" + dispositivo.Id,
                        entity_type = "Temp",
                        protocol = "PDI-IoTA-UltraLight", // verificar protocolo
                        transport = "MQTT",

                        commands = new[]
                        {
                            new { name = "on", type = "command" },
                            new { name = "off", type = "command" }
                        },

                        attributes = new[]
                        {
                            new { object_id = "s", name = "state", type = "Text" },
                            new { object_id = "l", name = "luminosity", type = "Integer" }
                        }
                    }
                }
            };

            return client.PostAsJsonAsync("iot/devices", body);
        }

        //O IP da URL é 1026 - url:1026/vs/registrations
        public Task RegistrarDispositivoAsync(DispositivoViewModel dispositivo)
        {
            var body = new
            {
                description = "Temp Commands",
                dataProvided = new
                {
                    entities = new[]
                    {
                        new { id = "urn:ngsi-ld:Lamp:001", type = "Lamp" }
                    },
                    attrs = new[]
                    {
                        "on", "off" // Verificar sintaxe
                    }
                },
                provider = new
                {
                    http = new { url = "http://{{url}}:4041" },
                    legacyForwarding = true,
                }
            };

            return client.PostAsJsonAsync("v2/registrations", body);
        }

        public async Task<IEnumerable<DispositivoViewModel>?> ListarDispositivoAsync()
        {
            HttpResponseMessage response = await client.GetAsync("");
            return await response.Content.ReadFromJsonAsync<IEnumerable<DispositivoViewModel>>();
        }
    }
}
