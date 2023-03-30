using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Exceptions;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.Infrastructure.Repositories;

public class PostRepository : IPostRepository


{
    private readonly AppDbContext _postContext;
    public PostRepository(AppDbContext context)
    {
        _postContext = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        _postContext.Add(post);
        await _postContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post> GetByIdAsync(int? id)
    {
        return await _postContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        //return await _postContext.Posts.FindAsync(id);
    }

    public async Task<IEnumerable<Post>> GetPostAsync()
    {

        return await _postContext.Posts.ToListAsync();

    }

    public async Task<Post> RemoveAsync(Post post)
    {
        _postContext.Remove(post);
        await _postContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdateAsync(Post post)
    {
        try
        {
            _postContext.Update(post);//.State = EntityState.Modified;
            await _postContext.SaveChangesAsync();
            return post;

        }catch (DbUpdateConcurrencyException) { 
            if (await GetByIdAsync(post.Id) == null)
            {
                throw new RepositoryException("Post não encontrado!");
            }
            else { throw; }
        }
    }
}
