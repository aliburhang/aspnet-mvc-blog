using Blog.Web.Mvc;
using Blog.Web.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Session servisini ekle
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = ".Siliconmade.Session";

            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultMac");
            options.UseSqlServer(connectionString);
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
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

        // Session Kullan
        app.UseSession();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // category-index    /category/category-slug
        app.MapControllerRoute(
            name: "Kategori",
            pattern: "{controller=Category}/{category}-{slug}/{action=Index}");

        // blog-detail    /blog/title-slug
        app.MapControllerRoute(
            name: "Blog",
            pattern: "{controller=Blog}/{title}-{slug}/{action=Detail}");

        // page-detail    /page/title-slug
        app.MapControllerRoute(
            name: "Page",
            pattern: "{controller=Page}/{title}-{slug}/{action=Detail}");

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

