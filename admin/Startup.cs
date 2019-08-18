using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboardProject.Models;
using AdminDashboardProject.Services;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminDashboardProject
{
    public class Startup
    {

        public AdminDBContext adminDbContext;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Test Branch
            //Test 2
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AdminDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AdminConnectionString")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AdminDBContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();



            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<AdminDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("AdminConnectionString")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    // services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<AdminDBContext>()
            //    .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                {
                    //options.AllowAreas = true;
                    //options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    //options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                    options.Conventions.AuthorizePage("/Account/Login");
                });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Identity/Account/Login";
            //    options.LogoutPath = $"/Identity/Account/Logout";
            //    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            //});

            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});

            // using Microsoft.AspNetCore.Identity.UI.Services;
            // services.AddSingleton<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AdminDBContext dbContext)
        {
            //adminDbContext = dbContext;
            //adminDbContext.Database.EnsureCreated();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseAuthentication();
            //app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
