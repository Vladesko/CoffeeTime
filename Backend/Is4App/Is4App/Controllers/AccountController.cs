using App.Interfaces;
using DomainApp.Models;
using FluentValidation;
using Is4App.Map;
using Is4App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Is4App.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController(IUserService service) : ControllerBase
    {
        private readonly IUserService service = service;
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginUserRequest request)
        {
            var model = new UserMap().MapWith(request);
            var token = await service.Login(model);

            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody]RegistrationUserRequest request)
        {
            if (request.ConfirmPassword != request.Password)
                return BadRequest("Password is not confirm");


            var model = new UserMap().MapWith(request);
            await service.Registration(model);
            return Ok();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendCode([FromBody] ConfirmUserRequest request)
        {
            await service.SendCode(request.Email);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CodeConfirmation([FromBody] ConfirmUserRequest request)
        {
            await service.CheckCode(request.SecretCode, request.Email);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await service.GetUsers();
            return Ok(users);
        }
    }
}
