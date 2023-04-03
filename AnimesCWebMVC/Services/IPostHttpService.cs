using AnimesCWebMVC.Models;

namespace AnimesCWebMVC.Services
{
    public interface IPostHttpService
    {
        Task<IEnumerable<PostViewModel>> GetPosts(string token);
        Task<PostViewModel> GetPostByID(int id, string token);
        Task<PostViewModel> CreatePost(PostViewModel postVM, string token);
        Task<bool> UpdatePost(int id, PostViewModel postVM, string token);
        Task<bool> DeletePost(int id, string token);

    }
}
