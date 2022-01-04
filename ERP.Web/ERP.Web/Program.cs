using ERP.Web.Extensions;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.DBRegistration(configuration["ConnectionStrings:mysql"], Convert.ToInt32(configuration["env_setting:MYSQL_MAJOR_VER"]), Convert.ToInt32(configuration["env_setting:MYSQL_MINOR_VER"]), Convert.ToInt32(configuration["env_setting:MYSQL_BUILD_VER"]));
builder.Services.ConfigureJWT(configuration["env_setting:JWT_KEY"]);
builder.Services.RegisterMapping();
builder.Services.RegisterCoreClasses();

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
