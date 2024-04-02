using App.Interfaces;
using DomainApp.Models;
using Is4App.Map;
using Is4App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Is4App.Controllers
{
    public class AccountController(IUserService service) : Controller
    {
        private readonly IUserService service = service;
        [HttpGet]
        public IActionResult Login()
        {
            LoginUserRequest request = new LoginUserRequest();
            return View(request);
        }
            [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var model = new UserMap().MapWith(request);
            var token = await service.Login(model);

            return Redirect($"http://localhost:5500/personal.html?access_token={token}");
        }
        [HttpGet]
        public IActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationUserRequest request)
        {
            if (request.ConfirmPassword != request.Password)
                return BadRequest("Password is not confirm");

            var model = new UserMap().MapWith(request);
            await service.Registration(model);
            return Redirect("https://localhost:7188/Account/Login");
        }
    }
}
