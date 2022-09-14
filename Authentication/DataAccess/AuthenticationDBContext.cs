using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccess
{
    public class AuthenticationDBContext : DbContext
    {
        public AuthenticationDBContext() { }
        public AuthenticationDBContext(DbContextOptions options):base(options) { }

        public DbSet<Authentications> Authentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableName(modelBuilder);
        }

        private static void SnakeCaseIdentityTableName(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentications>(b => { b.ToTable("Authentication"); });

        }



    }
}
