using MotHistoryFinder.Models;
using System.Text.Json;

namespace MotHistoryFinder.Services
{
    public class MotHistoryService : IMotHistoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public MotHistoryService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _config = configuration;
        }

        public async Task<List<MotHistoryDto>> GetMotHistory(string queryStringValue)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_config.GetValue<string>("ApiSettings:Endpoint")}{queryStringValue}");
            request.Headers.Add("x-api-key", _config.GetValue<string>("ApiSettings:Key"));
            request.Headers.Add("description", "");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var motHistoryDto = await JsonSerializer.DeserializeAsync<List<MotHistoryDto>>(responseStream);
                if (motHistoryDto != null)
                    return motHistoryDto;
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }

            return new List<MotHistoryDto>();
        }
    }
}
