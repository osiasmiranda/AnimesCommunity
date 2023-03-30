using SocialNetwork.Domain.Entites;

namespace SocialNetwork.Domain.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetPostAsync();
    Task<Post> GetByIdAsync(int? id);
    Task<Post> CreateAsync(Post post);
    Task<Post> UpdateAsync(Post post);
    Task<Post> RemoveAsync(Post post);
}
