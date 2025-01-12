using EFitnessAPI.Data;
using EFitnessAPI.Models; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure EF Core using your Azure SQL Database
builder.Services.AddDbContext<EFitnessContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFitnessContext")));

// 2. Configure JWT Authentication (optional if you don't need JWT)
var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSection["Key"] ?? "SomeDevFallbackKey")),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// 3. Register controllers
builder.Services.AddControllers();

// 4. Register Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Always enable Swagger, even in production, so you can test on Azure
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Serve the Swagger JSON at /swagger/v1/swagger.json
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFitnessAPI v1");
    // Put Swagger at root (/). If you prefer /swagger, remove this line:
    c.RoutePrefix = string.Empty;
});

// (Optional) If you have a custom domain SSL or prefer no HTTP, keep this:
app.UseHttpsRedirection();

// 6. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 7. Map controllers at e.g. /api/members
app.MapControllers();

// 8. Run the application
app.Run();
