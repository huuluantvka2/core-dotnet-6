using Data;
using Data.Infracstructure;
using Microsoft.EntityFrameworkCore;
using Service;

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

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
