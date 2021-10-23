using Core.Entities.Enums;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration config)
        {

            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IAuthorRepository, AuthorRepository>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IPublisherRepository, PublisherRepository>();
            service.AddScoped<IPublisherService, PublisherService>();
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IBorrowRepository, BorrowRepository>();
            service.AddScoped<IBorrowService, BorrowService>();
            service.AddScoped<ILibraryInformation, LibraryInformationService>();


            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            service.AddDbContext<LibrosContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SqlServerConnectionString"));
            });

            service.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<LibrosContext>();

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false,
                    };
                });

            service.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRoleRequire", policy => policy.RequireRole(RolesEnum.Admin.ToString()));
                opt.AddPolicy("MemberRoleRequire", policy => policy.RequireRole(RolesEnum.Member.ToString(), RolesEnum.Admin.ToString()));
                opt.AddPolicy("ModeratorRoleRequire", policy => policy.RequireRole(RolesEnum.Moderator.ToString(), RolesEnum.Admin.ToString()));


            });

            return service;
        }
    }
}
