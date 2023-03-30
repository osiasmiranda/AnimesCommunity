using SocialNetwork.Application.DTOs;

namespace SocialNetwork.Application.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostDTO>> GetPosts();
    Task<PostDTO> GetById(int? id);
    Task Add(PostDTO postDto);
    Task Update(PostDTO postDto);
    Task Remove(int? id);

}
