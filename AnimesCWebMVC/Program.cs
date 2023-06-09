using AnimesCWebMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddHttpClient("AnimesApi", c => 
{
    //c.BaseAddress = new Uri("https://localhost:44367/");
    c.BaseAddress = new Uri("https://localhost:7218/");
});

builder.Services.AddHttpClient("AuthenticatedApi", c =>
{
    c.BaseAddress = new Uri("https://localhost:7218/");
    //c.BaseAddress = new Uri("https://localhost:44367/");
    c.DefaultRequestHeaders.Accept.Clear();
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddScoped<IPostHttpService, PostHttpService>();
builder.Services.AddScoped<IProfileHttpService, ProfileHttpService>();
builder.Services.AddScoped<IAuthentication, Authentication>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
