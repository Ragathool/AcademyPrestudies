using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademyPrestudies
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Odin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<MuninContext>(o => o.UseSqlServer(connString));
            services.AddTransient<AssignmentRepository>();

            services.AddAuthentication(
            CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o => o.LoginPath = "/Account/LogIn");

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connString));

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            // Only needed if login path shoudn't be "/Account/Login" 
            services.ConfigureApplicationCookie(o => o.LoginPath = "/LogIn");

            services.AddTransient<AccountRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseAuthentication();
                app.UseSession();
                app.UseMvcWithDefaultRoute();
                app.UseStaticFiles();
               
            }
        }
    }
}
