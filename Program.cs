using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Inflowmation.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<InflowmationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("InflowmationContext") ?? throw new InvalidOperationException("Connection string 'InflowmationContext' not found.")));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<InflowmationContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("InflowmationContext")));
}

builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("CookieSettings", options));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<InflowmationContext>();
//else
//{
//    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext")));
//}

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    //options.Cookie.Expiration 

    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
    //options.ReturnUrlParameter=""
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
