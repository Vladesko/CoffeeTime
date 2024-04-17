using DomainApp.Models;

namespace App.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetUserByUserNameAsync(string userName);
        Task SendCodeByEmailAsync(string email);
        Task CheckCodeByEmailAsync(int code, string email);
        Task<List<User>> GetUsersWithoutEmailConfirmdAsync();
    }
}
