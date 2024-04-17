using App.Comon.Exceptions;
using App.Interfaces;
using DomainApp.Models;
using Infastructure.Comons.Exceptions;
using Infastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class UserRepository(AuthorizeDbContext context, IEmailService emailService) : IUserRepository
    {
        private readonly IEmailService emailService = emailService;
        private readonly AuthorizeDbContext context = context;
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user, new CancellationToken());
            await context.SaveChangesAsync(new CancellationToken());
        }
        public async Task SendCodeByEmailAsync(string email)
        {
            var user = await FindByEmailAsync(email);

            user.SecretCode = await emailService.SendCode(user.Email);

            await context.SaveChangesAsync(new CancellationToken());
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName, new CancellationToken());
            return user ?? throw new UserNotFoundException("User is not found with this name");
        }
        public async Task<List<User>> GetUsersWithoutEmailConfirmdAsync()
        {
            var users = await context.Users.Where(u => u.EmailConfimed == false).
                                            ToListAsync(new CancellationToken());
            return users;
        }
        public async Task CheckCodeByEmailAsync(int code, string email)
        {
            var user = await FindByEmailAsync(email);
            if (user.SecretCode != code)
                throw new AccessDeniedException("Code is wrong");

            user.EmailConfimed = true;
            await context.SaveChangesAsync(new CancellationToken());
        }
        private async Task<User> FindByEmailAsync(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email, new CancellationToken());
            return user ?? throw new UserNotFoundException("User is not found with this email");
        }

    }
}
