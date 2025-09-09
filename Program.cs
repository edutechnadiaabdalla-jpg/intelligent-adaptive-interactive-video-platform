//add-me
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BBSWebApplication.Areas.Identity.Data;
using BBSWebApplication.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

        //builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        //false edit-me
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        //add-me
        builder.Services.AddRazorPages();
        //builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/identity/mymainitems", ""));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        //add-me
        app.MapRazorPages();

        app.Run();
    }
}
