global using Microsoft.EntityFrameworkCore;

using System.Net;

using Policy.Data;
using Policy.Models;

using PolicyMicroservice.Repo;

var builder = WebApplication.CreateBuilder(args);

// const string aNGULAR_CORS_POLICY = "Dev_Angular_App";
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

builder
    .Services
    .AddDbContext<PolicyContext>(option =>
    {
        string? userName = null;

        if (builder.Environment.IsProduction())
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_PolicyAdmin");
            if (connectionString is null)
                option.UseInMemoryDatabase("PolicyDB");
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
            .GetConnectionString($"{userName}PolicyDB"));
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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    using var client = new HttpClient();
    try
    {
        var bearer = context.Request.Headers.Authorization;

        if (bearer.Count == 0)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.CompleteAsync();
            return;
        }

        var token = bearer[0].Split(" ")[1];
        Console.WriteLine($"Bearer: {token}");
        string? baseUri = null;
        if (app.Environment.IsDevelopment())
            baseUri = app.Configuration["Service:AuthLocal"];
        else if (app.Environment.IsProduction())
            baseUri = app.Configuration["Service:AuthProduction"];

        app.Logger.Log(LogLevel.Information, "Authentication Service Uri: {baseUri}", baseUri);

        client.BaseAddress = new Uri(baseUri!);
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
