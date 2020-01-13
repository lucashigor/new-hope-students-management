using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using New.Hope.Application.Interfaces.ExternalServices;
using New.Hope.Domain;
using Newtonsoft.Json;

namespace New.Hope.Infra.ExternalServices
{
    public class IbgeExternalService : IIbgeExternalService
    {
        private readonly HttpClient _client;

        public IbgeExternalService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://servicodados.ibge.gov.br/");

        }
        public async Task<List<Region>> RegionsAsync()
        {
            var returned = _client.GetAsync("api/v1/localidades/regioes").Result;

            var jsonResult = await returned.Content.ReadAsStringAsync();

            var listRegions = JsonConvert.DeserializeObject<List<Region>>(jsonResult);

            return listRegions;
        }
    }
}
