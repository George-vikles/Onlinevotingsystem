using Microsoft.EntityFrameworkCore;
using Onlinevotingsystem.Data;
using ApplicationDbContext;
using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
using Onlinevotingsystem;
=======
>>>>>>> 90767b96c834dec37d2e5b8f219bb43fbb8e6310

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with SQL Server
builder.Services.AddDbContext<Onlinevotingsystem.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<cs>();
<<<<<<< HEAD
=======

var app = builder.Build();
>>>>>>> 90767b96c834dec37d2e5b8f219bb43fbb8e6310

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    await SeedData.Initialize(scope.ServiceProvider);
}
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();