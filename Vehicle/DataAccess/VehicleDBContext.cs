using Microsoft.EntityFrameworkCore;

namespace Vehicle.DataAccess
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext() { }
        public VehicleDBContext(DbContextOptions options):base(options) { }

        public DbSet<Vehicle> Authentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableName(modelBuilder);
        }

        private static void SnakeCaseIdentityTableName(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(b => { b.ToTable("Authentication"); });

        }



    }
}
