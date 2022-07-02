global using Microsoft.EntityFrameworkCore;

using Authentication.Context;
using Authentication.Repo;

// const string aNGULAR_CORS_POLICY =w "Dev_Angular_App";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthContext>(option =>
    {
        string? userName = null;

        if (builder.Environment.IsProduction())
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_PolicyAdmin");

            if (connectionString is null)
            {
                option.UseInMemoryDatabase("AuthDB");
            }
            else
            {
                Console.WriteLine($"Connection String {connectionString}");
                option.UseSqlServer(connectionString);
            }
            return;
        }

        if (OperatingSystem.IsLinux())
        {
            userName = Environment.GetEnvironmentVariable("USERNAME")
            ?? throw new Exception("env variable USERNAME not found");
        }
        else if (OperatingSystem.IsWindows())
        {
            userName = Environment.GetEnvironmentVariable("COMPUTERNAME")
             ?? throw new Exception("env variable USERNAME not found");
        }

        if (userName is null) throw new Exception("userName is null");

        option.UseSqlServer(builder.Configuration.GetConnectionString($"{userName}AuthDB"));
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAgentRepo, AgentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
