using AnimesCWebMVC.Models;

namespace AnimesCWebMVC.Services
{
    public interface IPostHttpService
    {
        Task<IEnumerable<PostViewModel>> GetPosts();
        Task<PostViewModel> GetPostByID(int id);
        Task<PostViewModel> CreatePost(PostViewModel postVM);
        Task<bool> UpdatePost(int id, PostViewModel postVM);
        Task<bool> DeletePost(int id);

    }
}
