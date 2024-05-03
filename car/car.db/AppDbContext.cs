using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using w.sale.car.model.Model;


namespace w.sale.car.db
{
    public class AppDbContext : DbContext
    {

        private readonly IConfiguration Config;
        public virtual DbSet<Location> location{ get; set; }
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<Car> car { get; set; }
        public virtual DbSet<Reserve> reserve { get; set; }
        public virtual DbSet<Sale> sale { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Location>(e =>
            {
                e.HasKey(k => k.IdLocation);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(k => k.IdUser);
            });

            modelBuilder.Entity<Car>(e =>
            {
                e.HasKey(k => k.IdCar);
            });

            modelBuilder.Entity<Reserve>(e =>
            {
                e.HasKey(k => k.IdReserve);
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(k => k.IdSale);
            });


            modelBuilder.HasDefaultSchema(Config.GetConnectionString("SchemaName"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
