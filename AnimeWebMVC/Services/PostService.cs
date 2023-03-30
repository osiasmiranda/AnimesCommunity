using AnimeWebMVC.Models;
using System.Text.Json;

namespace AnimeWebMVC.Services
{
    public class PostService : IPostService

    {
        private const string apiEndpoint = "api/Posts/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly PostViewModel _postVM;
        private IEnumerable<PostViewModel> postsVM;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive=true};
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PostViewModel> CreatePost(PostViewModel postVM)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePos(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PostViewModel> GetPostByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostViewModel>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePost(int id, PostViewModel postVM)
        {
            throw new NotImplementedException();
        }
    }
}
