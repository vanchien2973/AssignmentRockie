using AssignmentDay3.Interfaces;
using AssignmentDay3.Middlewares;
using AssignmentDay3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ILogFileService, LogFileService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
