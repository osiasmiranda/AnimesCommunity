using SocialNetwork.Domain.Entites;

namespace SocialNetwork.Domain.Interfaces;

public interface IProfileRepository
{
    Task<IEnumerable<Profile>> GetProfileAsync();
    Task<Profile> GetByIdAsync(string? id);
    Task<Profile> CreateAsync(Profile profile);
    Task<Profile> UpdateAsync(Profile profile);
    Task<Profile> RemoveAsync(Profile profile);
}
