using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using GydraAPI.Context;
using GydraAPI.Dtos;
using GydraAPI.Entities;
using GydraAPI.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PgDbConnection"));
});
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "localhost";
    opt.InstanceName = "local";
});
builder.Services.AddTransient<AbstractRepository<Pump>,PumpRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(corsPolicyBuilder => { corsPolicyBuilder.AllowAnyOrigin(); });
app.MapControllers();
app.Run();