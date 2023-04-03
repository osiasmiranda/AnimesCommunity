using AnimesCWebMVC.Models;

namespace AnimesCWebMVC.Services
{
    public interface IProfileHttpService
    {
        Task<IEnumerable<ProfileViewModel>> GetProfiles(string token);
        Task<ProfileViewModel> GetProfileByID(int id,string token);
        Task<ProfileViewModel> CreateProfile(ProfileViewModel postVM, string token);
        Task<bool> UpdateProfile(int id, ProfileViewModel postVM,string token);
        Task<bool> DeleteProfile(int id, string token);

    }
}
