using SocialNetwork.Application.DTOs;

namespace SocialNetwork.Application.Interfaces;

public interface IProfileService 
{
    Task<IEnumerable<ProfileDTO>> GetProfiles();
    Task<ProfileDTO> GetById(string? id);
    Task Add(ProfileDTO profileDto);
    Task Update(ProfileDTO profileDto);
    Task Remove(string? id);

}
