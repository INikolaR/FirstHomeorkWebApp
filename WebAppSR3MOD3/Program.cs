using DatabaseLib;
using NewVariant.Interfaces;
using WebAppSR3MOD3.Services;
using WebAppSR3MOD3.Services.Interfaces;

namespace WebAppSR3MOD3
{
    // Рупчев Николай Ильич БПИ223, самостоятельная работа 3 можуль 3.
    /// <summary>
    /// The main class of my app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class of the application.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IDataAccessLayer, DataAccessLayer>();
            builder.Services.AddSingleton<IDataBase, DataBase>();
            builder.Services.AddSingleton<IDataBaseHandlerService, DataBaseHandleService>();


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
        }
    }
}