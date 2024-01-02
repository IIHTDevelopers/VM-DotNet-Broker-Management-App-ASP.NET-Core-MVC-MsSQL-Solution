using Microsoft.EntityFrameworkCore;
using BrokerManagementApp.DAL;
using BrokerManagementApp.DAL.Interface;
using BrokerManagementApp.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BrokerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("ConnStr"));
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IBrokerInterface, BrokerManagementService>();
builder.Services.AddScoped<IBrokerRepository, BrokerRepository>();
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

app.Run();
