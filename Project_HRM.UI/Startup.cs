using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_HRM.Common.Mappings;
using Project_HRM.DATA.DataContext;
using Project_HRM.DATA.DbModels;

namespace Project_HRM.UI
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

            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            //services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();
            //services.AddScoped<IEmployeeLeaveRequestBusinessEngine, EmployeeLeaveRequestBusinessEngine>();
            //services.AddScoped<IEmployeeLeaveAssignBusinessEngine, EmployeeLeaveAssignBusinessEngine>();
            //services.AddScoped<IEmployeeBusinessEngine, EmployeeBusinessEngine>();
            services.AddAutoMapper(typeof(Maps));
            services.AddIdentity<Employee, IdentityRole>().AddDefaultTokenProviders()
               .AddEntityFrameworkStores<ProjectContext>();

            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddMvc();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
