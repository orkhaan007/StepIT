using Newtonsoft.Json.Linq;

namespace Movie_Worker.Services
{
    public class Requst
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "ec7da663";

        public Requst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JObject> SearchFilmsAsync(string letter, int page = 1)
        {
            var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?s={letter}&page={page}&apikey={_apiKey}");
            return JObject.Parse(response);
        }
    }
}
