using DL;
using BL;
using Serilog;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering our deps here for dependency injection
builder.Services.AddScoped<IRepo>(ctx => new DBRepo(builder.Configuration.GetConnectionString("CYFDB")));
builder.Services.AddScoped<IBL, CYFBL>();

//logging
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.File("../YarnDL/LoggingInfo.txt");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
