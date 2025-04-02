using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Repositories;
using MVC_NET_Core_Assignment_1.Repositories.Interfaces;
using MVC_NET_Core_Assignment_1.Services;
using MVC_NET_Core_Assignment_1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDummyData, DummyData>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddControllersWithViews();

// Configure HTTPS port explicitly
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5072); 
    options.ListenAnyIP(7175, listenOptions => 
    {
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Use HTTPS redirection with explicit ports
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "nashtech",
    pattern: "NashTech/{controller=Person}/{action=Index}/{id?}"
);

app.Run();