namespace Blog.Web.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
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

        // /category/aaa-bbb
        app.MapControllerRoute(
            name: "category",
            pattern: "{controller=Category}/{category}-{slug}/{action=Index}");

        // /blog/title-aaa
        app.MapControllerRoute(
            name: "blog",
            pattern: "{controller=Blog}/{title}-{slug}/{action=Detail}");

        // /page/title-aaa
        app.MapControllerRoute(
            name: "page",
            pattern: "{controller=Page}/{title}-{slug}/{action=Detail}");


        app.Run();
    }
}

