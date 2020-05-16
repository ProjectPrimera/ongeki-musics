using Microsoft.EntityFrameworkCore;
using OngekiMusics.Entities;

namespace OngekiMusics.Models {
    public class ApplicationDbContext : DbContext {
        public DbSet<Application> Applications { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //
        }
    }
}
