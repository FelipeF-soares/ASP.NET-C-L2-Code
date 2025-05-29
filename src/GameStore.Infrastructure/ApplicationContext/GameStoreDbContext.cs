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
        modelBuilder.Entity<Box>().OwnsOne(b => b.Dimensions);

        modelBuilder.Entity<Order>().Property(order => order.Id).ValueGeneratedNever();


        modelBuilder.Entity<Order>().HasMany(p => p.Products)
                                    .WithOne(p => p.Order)
                                    .HasForeignKey(p => p.OrderId)
                                    .OnDelete(DeleteBehavior.Cascade);

        

        modelBuilder.Entity<Box>().HasData(
            new
            {
                Id = 1,
                Name = "Caixa 1",
                Dimensions_Height = 30,
                Dimensions_Width = 40,
                Dimensions_Depth = 80,
                Dimensions_Volume = 96000
            },
            new
            {
                Id = 2,
                Name = "Caixa 2",
                Dimensions_Height = 80,
                Dimensions_Width = 50,
                Dimensions_Depth = 40,
                Dimensions_Volume = 160000
            },
            new
            {
                Id = 3,
                Name = "Caixa 3",
                Dimensions_Height = 50,
                Dimensions_Width = 80,
                Dimensions_Depth = 60,
                Dimensions_Volume = 240000
            }
        );
    }
}
