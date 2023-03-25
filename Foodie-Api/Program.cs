global using Foodie_Api.Models;
global using Foodie_Api.Services.UserService;
global using Foodie_Api.Dtos.User;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Foodie_Api.Data;
using Foodie_Api.Controllers;

var builder = WebApplication.CreateBuilder(args);


var mySqlConectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add Connection String
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(mySqlConectionString, ServerVersion.AutoDetect(mySqlConectionString)));
// Add services to the container.

//Cors Configuration
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Automapper Dependency Injection
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IUserService, UserService>();    //Dependency Injecting

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("https://localhost:7197");
});

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
