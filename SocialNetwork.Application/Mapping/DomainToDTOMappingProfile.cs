using SocialNetwork.Application.DTOs;
using SocialNetwork.Domain.Entites;
using Profile = SocialNetwork.Domain.Entites.Profile;

namespace SocialNetwork.Application.Mapping;

public class DomainToDTOMappingProfile : AutoMapper.Profile
{

    public DomainToDTOMappingProfile()
    {
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<Profile, ProfileDTO>().ReverseMap();
    }
}
