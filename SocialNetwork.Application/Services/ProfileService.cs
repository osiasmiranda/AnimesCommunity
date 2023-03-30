using AutoMapper;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Interfaces;

namespace SocialNetwork.Application.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;
    public ProfileService(IProfileRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository??throw new ArgumentNullException(nameof(IProfileRepository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProfileDTO>> GetProfiles()
    {
        var profilesEntity = await _profileRepository.GetProfileAsync();
        return _mapper.Map<IEnumerable<ProfileDTO>>(profilesEntity);

    }

    public async Task<ProfileDTO> GetById(int? id)
    {
        var profileEntity = await _profileRepository.GetByIdAsync(id);
        return _mapper.Map<ProfileDTO>(profileEntity);
    }
    public async Task Add(ProfileDTO profileDto)
    {
        var profilesEntity = _mapper.Map<Domain.Entites.Profile>(profileDto);
        await _profileRepository.CreateAsync(profilesEntity);
    }


    public async Task Update(ProfileDTO profileDto)
    {
        var profilesEntity = _mapper.Map<Domain.Entites.Profile>(profileDto);
        await _profileRepository.UpdateAsync(profilesEntity);
    }
    public async Task Remove(int? id)
    {
        var profileEntity = _profileRepository.GetByIdAsync(id).Result;
        await _profileRepository.RemoveAsync(profileEntity);
    }

}
