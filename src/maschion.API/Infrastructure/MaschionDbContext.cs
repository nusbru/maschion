using Microsoft.EntityFrameworkCore;
using maschion.API.Domain;

namespace maschion.API.Data
{
    public class MaschionDbContext : DbContext
    {
        public MaschionDbContext(DbContextOptions<MaschionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profiles");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.DateOfBirth);
                entity.Property(e => e.SupabaseId).HasMaxLength(50);
                // PostgreSQL-specific timestamp defaults
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt);

                // Define relationship with Orders (assuming you have a navigation property)
                entity.HasMany(p => p.Orders)
                      .WithOne(o => o.Profile)
                      .HasForeignKey(o => o.ProfileId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ProfileId).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");

                // PostgreSQL-specific timestamp defaults
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt);

                // Define relationship with Items
                entity.HasMany(o => o.Items)
                      .WithOne(i => i.Order)
                      .HasForeignKey(i => i.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.OrderId).IsRequired();

                // PostgreSQL-specific timestamp defaults
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Sellers");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ProfileId).IsRequired();

                entity.HasMany(o => o.Customers)
                      .WithOne(i => i.Seller)
                      .HasForeignKey(i => i.SellerId);
            });

            modelBuilder.Entity<Customer>(entity =>
           {
               entity.ToTable("Customers");
               entity.HasKey(e => e.Id);

               entity.Property(e => e.ProfileId).IsRequired();
               entity.Property(e => e.SellerId).IsRequired();
           });
        }
    }
}