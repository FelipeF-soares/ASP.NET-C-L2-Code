using GameStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.ApplicationContext;

public class GameStoreDbContext : DbContext
{
    public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Box> Boxes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

       // modelBuilder.Entity<Box>().Property(order => order.Id).ValueGeneratedNever();

        modelBuilder.Entity<Order>().HasMany(p => p.Products)
                                    .WithOne(p => p.Order)
                                    .HasForeignKey(p => p.OrderId)
                                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Box>().HasData(
            new
            {
                Id = 1,
                Name = "Caixa 1",
                Height = 30,
                Width = 40,
                Depth = 80,
                Volume = 96000
            },
            new
            {
                Id = 2,
                Name = "Caixa 2",
                Height = 80,
                Width = 50,
                Depth = 40,
                Volume = 160000
            },
            new
            {
                Id = 3,
                Name = "Caixa 3",
                Height = 50,
                Width = 80,
                Depth = 60,
                Volume = 240000
            },
            new
            {
                Id = 99,
                Name = "null",
                Height = 0,
                Width = 0,
                Depth = 0,
                Volume = 0
            }
        );
    }
}
