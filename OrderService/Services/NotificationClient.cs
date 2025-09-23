using System.Net.Http;
using System.Text.Json;
using System.Text;
using OrderService.DTO;

namespace OrderService.Services
{
    public class NotificationClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiGatewayUrl;
        public NotificationClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiGatewayUrl = config["ServiceUrls:ApiGateway"];

        }

        public async Task<string> AddNotification(NotificationDTO data)
        {
            // Serialize the DTO to JSON
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiGatewayUrl}/Notification/AddNotification", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
