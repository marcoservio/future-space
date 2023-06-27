using FutureSpace.Context;
using FutureSpace.Interfaces;
using FutureSpace.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
var connectionString = $"server={configuration["MYSQL_HOST"]};port={configuration["MYSQL_PORT"]};database=future_space;user={configuration["MYSQL_USER"]};password={configuration["MYSQL_PASSWORD"]}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Future Space", Version = "v1" });
});

builder.Services.AddScoped<ILaunchRepository, LaunchRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => "REST Back-end Challenge 20201209 Running");

app.MapControllers();

app.Run();
