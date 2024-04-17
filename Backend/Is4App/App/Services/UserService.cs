using App.Comon.Exceptions;
using App.Interfaces;
using DomainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserService(IPasswordHasher hasher, 
                             IUserRepository repository,
                             IJwtProvider provider,
                             IUserValidator validator) : IUserService
    {
        private readonly IUserValidator validator = validator;
        private readonly IPasswordHasher hasher = hasher;
        private readonly IUserRepository repository = repository;
        private readonly IJwtProvider provider = provider;

        public async Task Registration(RegistrationViewModel model)
        {
            validator.Validate(model);

            var hashPassword = hasher.HashPassword(model.Password);

            User user = new(Guid.NewGuid(), model.UserName, model.Email, model.NumberPhone, hashPassword);

            await repository.AddAsync(user);
        }

        public async Task<string> Login(LoginViewModel model)
        {
            var user = await repository.GetUserByUserNameAsync(model.UserName);
            if (user.EmailConfimed == false)
                throw new AccessDeniedException(user.Email);

            var result = hasher.Verify(model.Password, user.Password);

            if (result == false)
                throw new PasswordWrongException("Password is wrong");

            return provider.CreateToken(user);
        }
        public async Task<List<User>> GetUsers() =>
            await repository.GetUsersWithoutEmailConfirmdAsync();
        
        public async Task SendCode(string email)
        {
            await repository.SendCodeByEmailAsync(email);
        }
        public async Task CheckCode(int code, string email)
        {
            await repository.CheckCodeByEmailAsync(code, email);
        }
    }
}
