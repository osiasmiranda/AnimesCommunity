using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.Infrastructure.Repositories;

public class ProfileRepository : IProfileRepository 


{

    private readonly AppDbContext _profileContext;

    public ProfileRepository(AppDbContext context)
    {
        _profileContext = context;
    }
    public async Task<Profile> CreateAsync(Profile profile)
    {
        
        
        _profileContext.Profiles.Add(profile);
        await _profileContext.SaveChangesAsync();
        return profile;
    }

    public async Task<Profile> GetByIdAsync(string? id)
    {
        return await _profileContext.Profiles.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Profile>> GetProfileAsync()
    {
        return await _profileContext.Profiles.Include(p => p.Posts).ToListAsync();

    }

    public async Task<Profile> RemoveAsync(Profile profile)
    {
        _profileContext.Profiles.Remove(profile);
        await _profileContext.SaveChangesAsync();
        return profile;
    }

    public async Task<Profile> UpdateAsync(Profile profile)
    {
        _profileContext.Profiles.Update(profile).State = EntityState.Modified;
        await _profileContext.SaveChangesAsync();
        return profile;
    }

    public bool ProfileExists(string id)
    {
        return _profileContext.Profiles.Any(profile => profile.Id == id);
    }
}
