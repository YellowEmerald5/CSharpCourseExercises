using StarWarsPlanetsStats.ApiDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.APIInteraction
{
    public class APIReader : IApiDataReader
    {
        public async Task<string> Read(string baseAddress, string requestUri)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            HttpResponseMessage responseMessage = await client.GetAsync(requestUri);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
