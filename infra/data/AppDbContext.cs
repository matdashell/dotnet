using lojaDoDot.infra.data.entity;
using Microsoft.EntityFrameworkCore;

namespace lojaDoDot.infra.data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<NotificationEntity> NotificationEntities { get; set; }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}