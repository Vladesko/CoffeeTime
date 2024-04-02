using App.Comon;
using Infastructure.Comons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

string secretKey = string.Empty;

using (var sr = new StreamReader("D:\\Passwords\\SecretKey.txt", Encoding.UTF8, false))
{
    secretKey = sr.ReadToEnd();
}

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod(); //No restrictions
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddPersistance();
builder.Services.AddAppliaction();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        };

        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["OrderApi"];

                return Task.CompletedTask;
            }
        };

    });
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseMvc();

app.UseAuthentication();
app.UseAuthorization();



app.UseStaticFiles();
app.UseEndpoints(endponts =>
{
    endponts.MapDefaultControllerRoute();
});

app.Run();
