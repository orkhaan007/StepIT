using System.Text;
using Newtonsoft.Json;

namespace Face_API.Services
{
    public class FaceApiService : IFaceApiService
    {
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public FaceApiService(IConfiguration configuration)
        {
            _endpoint = configuration["AzureFaceApi:Endpoint"];
            _apiKey = configuration["AzureFaceApi:Key"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_endpoint)
            };
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
        }

        public async Task<string> DetectFacesAsync(string imageUrl)
        {
            var requestBody = JsonConvert.SerializeObject(new { url = imageUrl });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("face/v1.0/detect?returnFaceAttributes=age,gender", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Face API error: {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
