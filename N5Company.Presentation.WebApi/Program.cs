using N5Company.Core.Application;
using N5Company.Infrastucture.Persistence;
using N5Company.Presentation.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services of Core
builder.Services.AddApplicationLayer();

// Add services of Persistence
builder.Services.AddServiceInfrastructure(builder.Configuration);

// Add services of Api Versions
builder.Services.AddApiVersioningExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Add Middleware to intercept exceptions
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
