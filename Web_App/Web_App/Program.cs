using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_App.Areas.Identity.Data;
using Web_App.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Web_AppContextConnection") ?? throw new InvalidOperationException("Connection string 'Web_AppContextConnection' not found.");

builder.Services.AddDbContext<Web_AppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<StudentUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Web_AppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
