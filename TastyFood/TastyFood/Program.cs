using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TastyFood.Infrastructure.Data;
using TastyFood.Infrastructure.Data.Entities;
using static TastyFood.HelperMethods.AddDefaultIdentityOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TastyFoodDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => AddOptions(options))
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TastyFoodDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/ApplicationUser/Login";
    options.LogoutPath = "/ApplicationUser/Logout";
});

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
    app.UseStatusCodePages();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
app.MapRazorPages();

app.Run();
