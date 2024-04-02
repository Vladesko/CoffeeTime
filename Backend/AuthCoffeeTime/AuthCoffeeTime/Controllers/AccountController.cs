using AuthCoffeeTime.Entities;
using AuthCoffeeTime.Interfaces;
using AuthCoffeeTime.Models;
using AuthCoffeeTime.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthCoffeeTime.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IIdentityServerInteractionService interactionService;
        private readonly AuthDbContext context;
        private readonly IEmailService emailService;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IIdentityServerInteractionService interactionService,
                                 AuthDbContext context,
                                 IEmailService emailService)
        {
            this.emailService = emailService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.interactionService = interactionService;
            this.context = context;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel viewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Login error");
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User is not found");
                return View(model);
            }
            if (user.EmailConfirmed == false)
            {
                user.SecretCode = await emailService.SendCode(user.Email);
                await context.SaveChangesAsync();
                return RedirectToAction("CheckEmail", "Account");
            }

            if (user.EmailConfirmed == true)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                    return Redirect(model.ReturnUrl);

            }
            ModelState.AddModelError(string.Empty, "Login or password is wrong");
            return View(model);
        }
        [HttpGet]
        public IActionResult Registration(string returnUrl)
        {
            RegistrationViewModel viewModel = new RegistrationViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Registration error");
                ViewBag.Error = "Register not valid";
                return View(model);
            }
            if (ExistUser(model))
            {
                ModelState.AddModelError(string.Empty, "This user already exists");
                ViewBag.Error = "This user already exists";
                return View(model);
            }
            var user = new AppUser()
            {
                EmailConfirmed = false,
                Email = model.Email,
                PhoneNumber = model.NumberPhone,
                UserName = model.UserName,
                SecretCode = await emailService.SendCode(model.Email)
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction("CheckEmail", "Account");
            
            ModelState.AddModelError(string.Empty, "Registration error");
            return View(model);

        }
        [HttpGet]
        public IActionResult CheckEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CheckEmail(int secretCode)
        {
            var user = userManager.Users.Where(u => u.SecretCode == secretCode).FirstOrDefault();
            if (user == null)
                return BadRequest();

            user.EmailConfirmed = true;
            await context.SaveChangesAsync();
            return Redirect("http://localhost:5500/callback.html");
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await signInManager.SignOutAsync();
            var logoutRequest = await interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
        private bool ExistUser(RegistrationViewModel model)
        {
            //If new user in registration form add phone or login or userName or email its user not can be 
            return context.Users.Any(options =>
            options.PhoneNumber == model.NumberPhone ||
            options.Email == model.Email ||
            options.UserName == model.UserName);
        }
    }
}
