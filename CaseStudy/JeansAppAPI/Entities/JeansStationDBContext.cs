using Microsoft.EntityFrameworkCore;

namespace JeansAppAPI.Entities
{

    public class JeansStationDBContext : DbContext
    {
        public IConfiguration configuration;

        public JeansStationDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

       
        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
       
        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Transaction>Transactions { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply unique constraint on Email
            modelBuilder.Entity<User>()
                
                .HasIndex(u => u.Email)
                .IsUnique();
            


            // Additional configurations can be done here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database provider and connection string here
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("JeansAppConnection"));
        }
    }
}













