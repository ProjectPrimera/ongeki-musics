using Microsoft.EntityFrameworkCore;
using OngekiMusics.Entities;
using OngekiMusics.Extensions;

namespace OngekiMusics.Models {
    public class ApplicationDbContext : DbContext {
        public DbSet<SeasonalVersion> SeasonalVersions { get; set; }
        public DbSet<MusicCategory> MusicCategories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeasonalVersion>().UseTimestampedProperty();
            modelBuilder.Entity<MusicCategory>().UseTimestampedProperty();
            modelBuilder.Entity<Chapter>().UseTimestampedProperty();
        }
    }
}
