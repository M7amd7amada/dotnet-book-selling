using BookSelling.DataAccess.Data;
using BookSelling.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace BookSelling.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.AddDbContext();
        builder.AddRouting();
        builder.AddAuthentication();
        builder.AddOpenApi();
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("SqlServer");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    public static void AddRouting(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddHttpsRedirection(options => options.HttpsPort = 44350);
    }

    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));
    }

    public static void AddOpenApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
}