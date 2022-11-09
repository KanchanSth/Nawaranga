using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Data;
using Nawaranga.Data.Services;
using Nawaranga.Models;

var builder = WebApplication.CreateBuilder(args);

//dbcontext configuration

builder.Services.AddDbContext<AppDbContext>(optionsAction: options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//register service to inject it to the controller- services configuration

builder.Services.AddScoped<IRoomsService, RoomsService>();

builder.Services.AddScoped<IGuestsService,GuestsService>();

builder.Services.AddScoped<IStaffsService, StaffsService>();

//Authentication and Authorization

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed Database
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
app.Run();
