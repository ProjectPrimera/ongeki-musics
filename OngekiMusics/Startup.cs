using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace OngekiMusics {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            var server = Configuration?["Connection:Server"] ?? "server";
            var port = Configuration?["Connection:Port"] ?? "3306";
            var database = Configuration?["Connection:Database"] ?? "db";
            var user = Configuration?["Connection:User"] ?? "user";
            var password = Configuration?["Connection:Password"] ?? "password";

            services.AddDbContextPool<Models.ApplicationDbContext>(options => options
                .UseMySql($"Server={server};port={port};Database={database};User={user};Password={password};", mySqlOptions => {
                    mySqlOptions.EnableRetryOnFailure(30, TimeSpan.FromSeconds(10), null);
                    mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend);
                }
            ));

            services.AddControllersWithViews()
#if DEBUG
            .AddRazorRuntimeCompilation()
#endif
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}



