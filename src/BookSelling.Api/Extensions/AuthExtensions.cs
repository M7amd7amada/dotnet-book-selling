using System.Text;

using BookSelling.DataAccess.Data;
using BookSelling.Domain.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookSelling.Api.Extensions;

public static class AuthExtensions
{
    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        builder.AddIdentity();

        builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme =
            options.DefaultScheme =
            options.DefaultChallengeScheme =
            options.DefaultSignInScheme =
            options.DefaultForbidScheme =
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme)

            .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"]!);
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JWT:Issure"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                }
        );
    }

    public static void AddIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<ApiUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            }
        ).AddEntityFrameworkStores<AppDbContext>();
    }
}