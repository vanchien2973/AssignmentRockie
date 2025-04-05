using System.Text.Json;
using ASP.NET_Core_API_Assignment_1.Application.DTOs;
using ASP.NET_Core_API_Assignment_1.Application.Interfaces;
using ASP.NET_Core_API_Assignment_1.Application.Mappings;
using ASP.NET_Core_API_Assignment_1.Application.Services;
using ASP.NET_Core_API_Assignment_1.Domain.Interfaces;
using ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence;
using ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TaskManagementDb"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddAutoMapper(typeof(TaskProfile).Assembly);

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Seed initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    DataSeeder.Seed(context);
}

app.Run();