using AnimesCWebMVC.Models;
using SocialNetwork.Domain.Entites;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AnimesCWebMVC.Services
{
    public class ProfileHttpService : IProfileHttpService
    {
        private const string apiEndpoint = "api/Profiles/";
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;
        private ProfileViewModel? profileVM;
        private IEnumerable<ProfileViewModel>? profilesViewModel;

        public ProfileHttpService(IHttpClientFactory httpClientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _clientFactory = httpClientFactory;
        }


        public async Task<IEnumerable<ProfileViewModel>> GetProfiles(string token)
        {
            var client = _clientFactory.CreateClient("AnimesApi");

            PutTokenInHeaderAuthorization(token, client);

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    profilesViewModel = await JsonSerializer.DeserializeAsync<IEnumerable<ProfileViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return profilesViewModel!;
            }
        }


        public async  Task<ProfileViewModel> GetProfileByID(int id, string token)
        {
            var client = _clientFactory.CreateClient("AnimesApi");
            PutTokenInHeaderAuthorization(token, client);

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    profileVM = await JsonSerializer.DeserializeAsync<ProfileViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }

                return profileVM!;

            }

        }

        public async  Task<ProfileViewModel> CreateProfile(ProfileViewModel profileVM, string token)
        {
            var client = _clientFactory.CreateClient("AnimesApi");
            PutTokenInHeaderAuthorization(token, client);

            var profile = JsonSerializer.Serialize(profileVM);
            StringContent content = new StringContent(profile, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    profileVM = await JsonSerializer.DeserializeAsync<ProfileViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return profileVM;
            }

        }


        public async  Task<bool> UpdateProfile(int id, ProfileViewModel profileVM, string token)
        {
            var client = _clientFactory.CreateClient("AnimesApi");
            PutTokenInHeaderAuthorization(token, client);

            using (var response = await client.PutAsJsonAsync(apiEndpoint + id, profileVM))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }



        public async  Task<bool> DeleteProfile(int id, string token)
        {
            var client = _clientFactory.CreateClient("AnimesApi");
            PutTokenInHeaderAuthorization(token, client);

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;


        }


        private static void PutTokenInHeaderAuthorization(string token, HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }

    }
}
