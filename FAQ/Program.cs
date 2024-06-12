using FAQ.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context with the dependency injection container.
builder.Services.AddDbContext<FaqDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Here we're setting up how our app responds to different addresses.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "custom",
        pattern: "{controller=Home}/{action=Index}/topic/{activeTopic}/category/{activeCategory}");

    // This is our backup route. If the web address doesn't match any other maps, our app uses this one.
    endpoints.MapDefaultControllerRoute();
});

app.Run();
