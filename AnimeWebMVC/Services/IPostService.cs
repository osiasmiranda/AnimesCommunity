using AnimeWebMVC.Models;

namespace AnimeWebMVC.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetPosts();
        Task<PostViewModel>GetPostByID(int id);
        Task<PostViewModel> CreatePost(PostViewModel postVM);
        Task<bool> UpdatePost(int id, PostViewModel postVM);
        Task<bool> DeletePos(int id);
    }
}
