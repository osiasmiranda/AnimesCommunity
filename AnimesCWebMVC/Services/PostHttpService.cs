using AnimesCWebMVC.Models;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AnimesCWebMVC.Services;

public class PostHttpService : IPostHttpService
{
    private const string apiEndpoint = "api/Posts";
    private readonly JsonSerializerOptions _options;
    private readonly IHttpClientFactory _clientFactory;
    private PostViewModel? postVM;
    private IEnumerable<PostViewModel>? postsVM;

    public PostHttpService(IHttpClientFactory httpClientFactory)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _clientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<PostViewModel>> GetPosts(string token)
    {
        //meu servico que busca no serviceUri
        var client = _clientFactory.CreateClient("AnimesApi");
        PutTokenInHeaderAuthorization(token, client);

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                postsVM = await JsonSerializer.DeserializeAsync<IEnumerable<PostViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
            return postsVM!;

        }
    }

    public async Task<PostViewModel> GetPostByID(int id, string token)
    {
        var client = _clientFactory.CreateClient("AnimesApi");
        PutTokenInHeaderAuthorization(token, client);
        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                postVM = await JsonSerializer.DeserializeAsync<PostViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }

            return postVM;

        }
    }

    public async Task<PostViewModel> CreatePost(PostViewModel postVM,string token)
    {
        var client = _clientFactory.CreateClient("AnimesApi");
        PutTokenInHeaderAuthorization(token, client);
        var post = JsonSerializer.Serialize(postVM);
        StringContent content = new StringContent(post, Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                postVM = await JsonSerializer.DeserializeAsync<PostViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
            return postVM;
        }
    }
    public async Task<bool> UpdatePost(int id, PostViewModel postVM, string token)
    {
        var client = _clientFactory.CreateClient("AnimesApi");
        PutTokenInHeaderAuthorization(token, client);

        using (var response = await client.PutAsJsonAsync(apiEndpoint + id, postVM))
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

    public async Task<bool> DeletePost(int id, string token)
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
