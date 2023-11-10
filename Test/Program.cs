using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestDomainENT.Entities;
using TestRepositoryDAL.DAL.Implementation;
using TestRepositoryDAL.DAL.Interfaces;
using TestRepositoryDAL.Data;
using TestServiceBLL.BLL.Implementation;
using TestServiceBLL.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TestDBContext>(options => {
    // Our DATABASE_URL from js days
    string connectionString = Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<TestDBContext>()
        .AddDefaultTokenProviders();

builder.Services.AddTransient<IUserDAL, UserDAL>();
builder.Services.AddTransient<IUserBLL, UserBLL>();
builder.Services.AddScoped<IToDoListBLL, ToDoListBLL>();
builder.Services.AddScoped<IToDoListDAL, ToDoListDAL>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
