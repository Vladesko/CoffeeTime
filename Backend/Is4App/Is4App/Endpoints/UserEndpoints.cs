using App.Services;
using Is4App.Map;
using Is4App.ViewModels;

namespace Is4App.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("Registration", Registration);
            app.MapPost("login", Login);

            return app;
        }
        private static async Task<IResult> Registration(RegistrationUserRequest request, UserService service)
        {
            var model = new UserMap().MapWith(request);

            await service.Registration(model);

            return Results.Ok();
        }
        private static async Task<IResult> Login(LoginUserRequest request, UserService service, HttpContext context)
        {
            var model = new UserMap().MapWith(request);

            var token = await service.Login(model);

            context.Response.Cookies.Append("none", token);

            return Results.Ok(token);
        }
    }
}
