using E_Commerce_API.DTOs;

namespace E_Commerce_API.Repo.Contract
{
    public interface IAuthRepo
    {
        Task<string> Login(AuthLoginDTO dto);
        Task<bool> Register(AuthRegisterDTO dto);
    }
}
