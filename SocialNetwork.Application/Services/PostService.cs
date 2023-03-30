using AutoMapper;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Interfaces;

namespace SocialNetwork.Application.Services;

public class PostService : IPostService

{
    private IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostDTO>> GetPosts()
    {
        var postEntity = await _postRepository.GetPostAsync();
        return _mapper.Map<IEnumerable<PostDTO>>(postEntity);
    }
    public async Task<PostDTO> GetById(int? id)
    {
        var postEntity = await _postRepository.GetByIdAsync(id);
        return _mapper.Map<PostDTO>(postEntity);
    }
    public async Task Add(PostDTO postDto)
    {
        var postEntity = _mapper.Map<Post>(postDto);
        await _postRepository.CreateAsync(postEntity);
    }


    public async Task Update(PostDTO postDto)
    {
        var postEntity = _mapper.Map<Post>(postDto);
        await _postRepository.UpdateAsync(postEntity);
        
    }

    public async Task Remove(int? id)
    {
        var postEntity = _postRepository.GetByIdAsync(id).Result;
        await _postRepository.RemoveAsync(postEntity);
    }

}
