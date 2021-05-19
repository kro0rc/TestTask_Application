using System;
using System.Net.Http;
using TestProject_Consimple.Models;
using Newtonsoft.Json;

namespace TestProject_Consimple.Client
{ 
    internal class DataHttpClient : IDataHttpClient
    {
        private readonly HttpClient _client;

        public DataHttpClient(HttpClient client, Uri baseUri)
        {
            this._client = client;
            this._client.BaseAddress = baseUri;
        }

        public BaseModel GetProducts()
        {
            var response = _client.GetAsync(this._client.BaseAddress).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<BaseModel>(json);
        }
    }
}
