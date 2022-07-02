global using Microsoft.EntityFrameworkCore;

using Quotes.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<QuotesContext>(option =>
    {
        string? userName = null;

        if (builder.Environment.IsProduction())
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_PolicyAdmin");
            if (connectionString is null)
                option.UseInMemoryDatabase("QuotesDB");
            else
                option.UseSqlServer(connectionString);
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