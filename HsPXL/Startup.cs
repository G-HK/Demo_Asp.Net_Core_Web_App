using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HsPXL.Data;
using HsPXL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HsPXL
{
    public class Startup
    {
        // This project is currently in development
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // services.AddDbContext<HsPXLContext>(options =>  options.UseSqlServer(Configuration.GetConnectionString("HsPXLContext"))); //pre-setting

            services.AddDbContext<HsPXLContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:HsPXLContext"]);
            });

            services.AddScoped<IHsRepository, EFHsRepository>();

            services.AddSession();

            services.AddRazorPages();

            services.AddDbContext<HsIdentityDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));

            // importeren: using Microsoft.AspNetCore.Identity;
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<HsIdentityDbContext>();


            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/User/unauthorizedUser");


            //services.AddMvc(opts =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();  // this require users to be authenticated to get controller action
            //    opts.Filters.Add(new AuthorizeFilter(policy)); // (non [Authorize])
            //}).AddXmlSerializerFormatters();
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
              //  app.UseHsts();
            }
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app); // indentityData

        }
    }
}
