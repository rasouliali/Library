
using Library.Application.Dto;
using Library.Domain.Entities.UserEntities;

namespace Library.Application.Interfaces
{
    public interface IUserManagerRepository
    {
        Task<int> RegisterUser(UserInfo userInfo);
        Task<bool> TokenValidation(string Token, string Role, int userId);
        Task<bool> SignOut(string Token);
        Task<(bool, UserInfo)> SignIn(string username, string password);
        Task<(bool, UserInfo)> CheckUserPassAsync(string username, string password);
        Task<UserInfo> FindByUsernameAsync(string username);
        Task<UserInfo> GetAsync(int Id);
    }
}