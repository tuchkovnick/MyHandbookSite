using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyHandbookSite.Domain;
using MyHandbookSite.Domain.Repositories.Abstract;
using MyHandbookSite.Domain.Repositories.EFItemsRepository;
using MyHandbookSite.Models;
using MyHandbookSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        
            Configuration.Bind("Project", new Config());

            services.AddTransient<IItemsRepository, EFItemsRepository>();
            services.AddTransient<IItemTypesRepository, EFItemTypesRepository>();
            services.AddTransient<DataManager>();
            services.AddDbContext<AppDbContext>(options=> 
                {
                    options.UseSqlite(Config.ConnectionString);
                    options.EnableSensitiveDataLogging();
                }
            );

            services.AddIdentity<MyHandbookSiteUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "MyHabdbookSiteAuth";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("Admin"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.EnableEndpointRouting = false;
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })            
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
            .AddSessionStateTempDataProvider();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
