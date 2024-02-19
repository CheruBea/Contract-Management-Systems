using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserCompany.Areas.Identity.Data;
using UserCompany.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserCompanyDbContextConnection") ?? throw new InvalidOperationException("Connection string 'UserCompanyDbContextConnection' not found.");

builder.Services.AddDbContext<UserCompanyDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CompanyUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<UserCompanyDbContext>();

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

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
