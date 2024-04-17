using DomainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IUserService
    {
        Task Registration(RegistrationViewModel model);
        Task<string> Login(LoginViewModel model);
        Task SendCode(string email);
        Task CheckCode(int code, string email);
        Task<List<User>> GetUsers();
    }
}
