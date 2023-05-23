using Data;
using Data.Infracstructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model.Entities.Identities;
using Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Connect DB
var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
services.AddDbContext<BuildDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#region DI

services.AddHttpContextAccessor();
services.AddScoped<IDbFactory, DbFactory>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddRepositoryDI();
services.AddServiceDI();

#endregion

#region authentication jwt
services.AddIdentityCore<User>(opts =>
{
    opts.SignIn.RequireConfirmedAccount = false;
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequireDigit = false;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<BuildDbContext>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(otps =>
{
    otps.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

#endregion
services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Exc English API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer",
                }
            },
            new string[]{}
        }
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
