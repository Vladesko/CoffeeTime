using App.Interfaces;
using DomainApp.Models;
using Infastructure.Comons.Exceptions;
using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class UserRepository(AuthorizeDbContext context) : IUserRepository
    {
        private readonly AuthorizeDbContext context = context;
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync(new CancellationToken());
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName, new CancellationToken());
            if (user == null)
                throw new UserNotFoundException("User is not found with this name");

            return user;
        }
    }
}
