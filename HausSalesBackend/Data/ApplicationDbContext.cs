using HausSalesBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GeneralLedger> GeneralLedgers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GeneralLedger>(entity =>
            {
                entity.Property(e => e.glId)
                      .HasColumnType("uuid")
                      .IsRequired();
            });

            modelBuilder.Entity<Property>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<SalesRepresentative>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Prospect>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sale>()
            .HasOne(s => s.Prospect)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProspectId);

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role",
                CreatedDate = DateTime.UtcNow
            });
        }
    }
}
