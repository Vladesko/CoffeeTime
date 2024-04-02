using DomainApp.Models;

namespace App.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindByUserNameAsync(string userName);
    }
}
