using FormTrackClient.Models.Dtos;
using FormTrackClient.Models.Response;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FormTrackClient.Api
{
    public class ApiClient
    {
        private readonly HttpClient webClient;
        private readonly JsonSerializer serializer;
        private string BASE_ADDRESS = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7057/api/" : "https://localhost:7057/api/";

        public ApiClient()
        {
            var clientHandlerService = new HttpsClientHandlerService();
            webClient = new HttpClient(clientHandlerService.GetPlatformMessageHandler());
            webClient.BaseAddress = new Uri(BASE_ADDRESS);
            webClient.DefaultRequestHeaders.Add("accept", "*/*");
            serializer = new JsonSerializer();
        }

        public ApiClient(string token)
        {
            webClient = new HttpClient();
            webClient.BaseAddress = new Uri(BASE_ADDRESS);
            webClient.DefaultRequestHeaders.Add("accept", "*/*");
            webClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            serializer = new JsonSerializer();
        }

        public async Task<ResponseModel<LoginResponse>> LoginAsync(LoginDto dto)
        {
            try
            {
                HttpResponseMessage response = await webClient.PostAsync($"account/login", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                var contentStream = await response.Content.ReadAsStreamAsync();

                var streamReader = new StreamReader(contentStream);
                var jsonReader = new JsonTextReader(streamReader);

                return serializer.Deserialize<ResponseModel<LoginResponse>>(jsonReader);
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public async Task<ResponseModel<object>> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                HttpResponseMessage response = await webClient.PostAsync($"account/register", new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                var contentStream = await response.Content.ReadAsStreamAsync();

                var streamReader = new StreamReader(contentStream);
                var jsonReader = new JsonTextReader(streamReader);

                return serializer.Deserialize<ResponseModel<object>>(jsonReader);
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }
}