global using Microsoft.EntityFrameworkCore;

using Quotes.API.Data;

const string aNGULAR_CORS_POLICY = "Dev_Angular_App";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddDbContext<QuotesContext>(option => option.UseSqlServer(builder
        .Configuration
        .GetConnectionString("QuotesDB")));

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