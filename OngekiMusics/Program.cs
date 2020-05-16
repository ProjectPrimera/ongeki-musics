using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OngekiMusics.Models;

namespace OngekiMusics {
    public static class Program {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Migrate().Run();

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        public static IWebHost Migrate(this IWebHost host) {
            using(var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope()) {
                using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
            return host;
        }
    }
}
