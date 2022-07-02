global using Microsoft.EntityFrameworkCore;

using Quotes.API.Data;

const string aNGULAR_CORS_POLICY = "Dev_Angular_App";

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<QuotesContext>(option =>
    {
        string? userName = null;

        if (builder.Environment.IsProduction())
        {
            option.UseInMemoryDatabase("QuotesDB");
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

        option.UseSqlServer(builder
            .Configuration
            .GetConnectionString($"{userName}QuotesDB"));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .AddCors(o => o.AddPolicy(
        aNGULAR_CORS_POLICY,
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(aNGULAR_CORS_POLICY);

app.UseAuthorization();

app.MapControllers();

app.Run();