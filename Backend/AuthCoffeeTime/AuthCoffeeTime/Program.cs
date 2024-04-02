using AuthCoffeeTime;
using AuthCoffeeTime.Entities;
using AuthCoffeeTime.Interfaces;
using AuthCoffeeTime.Models;
using AuthCoffeeTime.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

string connectionString = string.Empty;

using (var sr = new StreamReader("D:\\Passwords\\AuthConnectionString.txt", Encoding.UTF8, false))
{
    connectionString = sr.ReadToEnd();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});


builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AuthDbContext>().
   AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
    {
        config.Authority = "https://localhost:7175";
        config.Audience = "api";
    });

builder.Services.AddAuthorization();

builder.Services.AddIdentityServer().
AddDeveloperSigningCredential().
    AddInMemoryClients(IS4Configuration.GetClients()).
    AddInMemoryApiScopes(IS4Configuration.GetApiScopes()).
    AddInMemoryApiResources(IS4Configuration.GetApiResources()).
    AddInMemoryIdentityResources(IS4Configuration.GetIdentityResources()).
    AddAspNetIdentity<AppUser>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "Order.Identity.Cookie";
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", policy =>
    {
        policy
            .AllowAnyMethod()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseRouting();
app.UseCors("all");

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.UseMvc();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
