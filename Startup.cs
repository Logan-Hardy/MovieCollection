using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddScoped<iMovieRepository, EFMovieRepository>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "Movies",
                    "Home/MovieList/{pageNum:int}",
                    new { Controller = "Home", action = "MovieList" });

                endpoints.MapControllerRoute(
                    "MoviePages",
                    "Home/MovieList/P{pageNum:int}",
                    new { Controller = "Home", action = "MovieList" });

                endpoints.MapControllerRoute(
                    "pagination",
                    //display urls as /P1, /P2, /P3, etc. 
                    "P{pageNum}",
                    new { Controller = "Home", action = "MovieList" });

                endpoints.MapControllerRoute(
                    "pageNum",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "MovieList" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
