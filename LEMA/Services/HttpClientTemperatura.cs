using PBL.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using LEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace LEMA.Services
{
    public class HttpClientTemperatura
    {
        private HttpClient client;
        private const string IP_MAQUINA = "191.232.181.249";
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

        public RetornoTemperatura? GetUltimaTemperatura(int idDispositivo)
        {
            return Task.Run(() => GetUltimaTemperaturaAsync(idDispositivo)).Result;
        }

        private async Task<RetornoTemperatura?> GetUltimaTemperaturaAsync(int idDispositivo)
        {
            HttpResponseMessage response = await client.GetAsync(url + "/STH/v1/contextEntities/type/Temp/id/urn:ngsi-ld:Temp:" + idDispositivo.ToString("D3") + "/attributes/temperature?lastN=1");
            return await response.Content.ReadFromJsonAsync<RetornoTemperatura>();
        }
        public async Task<List<TemperaturaViewModel>> GetTemperatura(int deviceId, DateTime? dateFrom = null, int hLimit = 100)
        {
            var allData = new List<TemperaturaViewModel>();
            bool moreData = true;
            DateTime? ultimaData = dateFrom;
            int lastN = 100;
            int hOffset = 0;
            while (moreData)
            {
                var queryParams = new List<string>
                {
                    $"lastN={lastN}",
                    $"hOffset={hOffset}"
                };

                if (ultimaData.HasValue)
                {
                    queryParams.Add($"dateFrom={ultimaData.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff")}");
                    DateTime? proximoMes = ultimaData.Value.AddDays(30);
                    queryParams.Add($"dateTo={proximoMes.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff")}");
                }
                if (hLimit > 0)
                    queryParams.Add($"hLimit={hLimit}");

                string queryString = string.Join("&", queryParams);
                var response = await client.GetAsync(url + $"/STH/v1/contextEntities/type/Temp/id/urn:ngsi-ld:Temp:{deviceId.ToString("D3")}/attributes/temperature?{queryString}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<RetornoTemperatura>();

                if (content.ContextResponses[0].ContextElement.Attributes[0].Values.Count() == 0)
                {
                    moreData = false;
                }
                else
                {
                    foreach (AttributeValues values in content.ContextResponses[0].ContextElement.Attributes[0].Values)
                    {
                        allData.Add(new TemperaturaViewModel
                        {
                            ValorTemperatura = values.attrValue,
                            DataLeitura = values.recvTime.Value,
                            IdDispositivo = deviceId
                        });
                    }
                    hOffset += hLimit;

                    var lastRecord = content.ContextResponses[0].ContextElement.Attributes[0].Values.Last();
                    ultimaData = lastRecord.recvTime ?? ultimaData;
                    ultimaData = ultimaData.Value.AddSeconds(1);
                }
            }

            return allData;
        }
    }
}
