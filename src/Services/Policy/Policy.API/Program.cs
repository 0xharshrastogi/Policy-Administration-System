global using Microsoft.EntityFrameworkCore;

using PolicyMicroservice.Context;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repo;

var builder = WebApplication.CreateBuilder(args);

const string aNGULAR_CORS_POLICY = "Dev_Angular_App";
// Add services to the container.

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

builder
    .Services
    .AddDbContext<PolicyContext>(option => option.UseInMemoryDatabase(builder.Configuration["DatabaseName"]));

builder
    .Services
    .AddScoped<IPolicyRepo<CustomerPolicy>, PolicyRepo>();

builder
    .Services
    .AddScoped<IIssuedPolicyRepo<IssuedPolicy>, IssuedPolicyRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DocumentTitle = builder.Configuration["ApplicationName"]
);
}

app.UseCors(aNGULAR_CORS_POLICY);

app.UseAuthorization();

app.MapControllers();

app.Run();
