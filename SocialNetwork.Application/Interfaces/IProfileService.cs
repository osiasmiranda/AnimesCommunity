using SocialNetwork.Application.DTOs;

namespace SocialNetwork.Application.Interfaces;

public interface IProfileService 
{
    Task<IEnumerable<ProfileDTO>> GetProfiles();
    Task<ProfileDTO> GetById(int? id);
    Task Add(ProfileDTO profileDto);
    Task Update(ProfileDTO profileDto);
    Task Remove(int? id);

}
