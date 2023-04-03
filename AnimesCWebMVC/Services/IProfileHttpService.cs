using AnimesCWebMVC.Models;

namespace AnimesCWebMVC.Services
{
    public interface IProfileHttpService
    {
        Task<IEnumerable<ProfileViewModel>> GetProfiles(string token);
        Task<ProfileViewModel> GetProfileByID(string id,string token);
        Task<ProfileViewModel> CreateProfile(ProfileViewModel postVM, string token);
        Task<bool> UpdateProfile(string id, ProfileViewModel postVM,string token);
        Task<bool> DeleteProfile(string id, string token);

    }
}
