global using Microsoft.EntityFrameworkCore;

using System.Net;

using Policy.Data;
using Policy.Models;

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
    .AddDbContext<PolicyContext>(option =>
    {
        var connectionString = builder.Configuration.GetConnectionString("PolicyDB");
        option.UseSqlServer(connectionString);
    });

builder
    .Services
    .AddScoped<IPolicyRepo<CustomerPolicy>, PolicyRepo>();

builder
    .Services
    .AddScoped<IIssuedPolicyRepo<IssuedPolicy>, IssuedPolicyRepo>();

builder
    .Services
    .AddScoped<IPolicyMasterRepo, PolicyMasterRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DocumentTitle = builder.Configuration["ApplicationName"]);
}

app.UseCors(aNGULAR_CORS_POLICY);

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    using var client = new HttpClient();
    const int pORT = 5090;
    try
    {
        var bearer = context.Request.Headers.Authorization;
        Console.WriteLine($"Bearer {bearer}");
        if (bearer.Count == 0)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.CompleteAsync();
            return;
        }

        var token = bearer[0].Split(" ")[1];
        Console.WriteLine(token);
        client.BaseAddress = new Uri($"http://localhost:{pORT}");
        var result = await client.PostAsJsonAsync("/api/Auth/Agent/Validate", new { token });

        await next(context);
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Catch");
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await context.Response.CompleteAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
});

app.Run();
