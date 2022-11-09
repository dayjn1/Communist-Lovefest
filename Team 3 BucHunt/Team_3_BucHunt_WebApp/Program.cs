using Team_3_BucHunt_WebApp.Services;

NotificationService ns = new NotificationService();

//ns.SendEmail("dayjn1@etsu.edu", "Testing app emails", "404 Industries - BucHunt testing");
ns.SendEmail("4233433261@sprintpaging.com", "Testing app emails", "404 Industries - BucHunt testing");


var builder = WebApplication.CreateBuilder(args);
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

