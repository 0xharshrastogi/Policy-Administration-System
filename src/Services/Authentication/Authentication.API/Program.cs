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

// builder
//     .Services
//     .AddCors(o => o.AddPolicy(
//         aNGULAR_CORS_POLICY,
//         policy => policy
//             .WithOrigins("http://localhost:4200")
//             .AllowAnyHeader()
//             .AllowAnyMethod())
//     );

builder.Services.AddDbContext<AuthContext>(option =>
{
    var connection = builder.Configuration.GetConnectionString("AuthDB");
    option.UseSqlServer(connection);
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
