using AnimesCWebMVC.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimesCWebMVC.Services
{
    public class Authentication : IAuthentication

    {
        private readonly IHttpClientFactory _httpClientFactory;
        const string apiEndpointAuthentication = "api/Auth/Login";
        private readonly JsonSerializerOptions _options;
        private TokenViewModel tokenUser;

        public Authentication(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<TokenViewModel> AuthenticationUser(UserViewModel userVM)
        {
            var client = _httpClientFactory.CreateClient("AuthenticatedApi");
            var usuario = JsonSerializer.Serialize(userVM);
            StringContent content = new StringContent(usuario,Encoding.UTF8,"application/json");

            using (var response = await client.PostAsync(apiEndpointAuthentication, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tokenUser = await JsonSerializer.DeserializeAsync<TokenViewModel>(apiResponse,_options);

                }else
                {
                    return null;
                }
            }
            return tokenUser;
        }
    }
}
