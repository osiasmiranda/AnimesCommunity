using AnimesCWebMVC.Models;

namespace AnimesCWebMVC.Services
{
    public interface IAuthentication
    {
        Task<TokenViewModel> AuthenticationUser(UserViewModel userVM);
    }
}
