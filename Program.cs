using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapp1.Models;
using webapp1.Services;
using webapp1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddDbContext<DataBaseContext>(a => a.UseSqlServer("data source=.;initial catalog=wp1;integrated security=true"));

builder.Services.AddIdentity<AppUser, AppRole>(op =>
{
    op.User.RequireUniqueEmail = true;
    op.User.AllowedUserNameCharacters = "hello";
    op.Password.RequireUppercase = false;
    op.Password.RequiredUniqueChars = 10;
    op.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<DataBaseContext>().AddUserManager<UserManager<AppUser>>();


var Configuration = builder.Configuration;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(a =>
{
    a.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:TokenKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();

app.Run();
