using Microsoft.EntityFrameworkCore;

namespace Quota.DataAccess
{
    public class QuotaDBContext : DbContext
    {
        public QuotaDBContext() { }
        public QuotaDBContext(DbContextOptions options):base(options) { }

        public DbSet<Quota> Authentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableName(modelBuilder);
        }

        private static void SnakeCaseIdentityTableName(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quota>(b => { b.ToTable("Authentication"); });

        }



    }
}
