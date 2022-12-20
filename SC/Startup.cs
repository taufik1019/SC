using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SC.Context;
using SC.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC
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
            services.AddScoped<AccountRepository>();
            services.AddScoped<KeluhanRepository>();
            services.AddScoped<ResponKeluhanRepository>();
            


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //services.AddDefaultIdentity<MyContext>(Options =>
            //Options.Login.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStore<MyContext>();


            services.AddDbContext<MyContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddControllersWithViews();
            services.AddControllersWithViews();
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

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                   pattern: "/{controller=Account}/{action=Login}/{id?}");

            });
        }
    }
}
