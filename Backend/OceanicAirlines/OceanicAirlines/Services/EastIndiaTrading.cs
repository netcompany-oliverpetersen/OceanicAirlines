using Newtonsoft.Json;
using OceanicAirlines.APIModels;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
namespace OceanicAirlines.Services
{
    public class EastIndiaTrading
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<IEnumerable<ApiRoute>> GetApiRoutes(APIRouteRequest req)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            string json = JsonConvert.SerializeObject(req);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://wa-eat-dk1.azurewebsites.net/api/route", httpContent);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var responses = JsonConvert.DeserializeObject<List<ApiRoute>>(responseBody);
            Console.Write(responseBody);
            return responses;
        }
    }
}
