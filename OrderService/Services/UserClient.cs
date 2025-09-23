namespace OrderService.Services
{
    public class UserClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiGatewayUrl;

        public UserClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiGatewayUrl = config["ServiceUrls:ApiGateway"];
        }
        public async Task<string> GetAllUsersFromGateway()
        {
            // Call the User service via API Gateway
            var response = await _httpClient.GetAsync($"{_apiGatewayUrl}/User/AllUser");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
