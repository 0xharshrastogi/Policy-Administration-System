using Consumer.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Consumer.API.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConsumerDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Connect")));
builder.Services.AddScoped<IConsumerRepository,ConsumerRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options=>options.DocumentTitle=builder.Configuration["ApplicationName"]);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
