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
        modelBuilder.Entity<Box>().HasData
            (
                new Box { Id=1, Name = "Caixa 1", Height = 30, Width = 40, Depth = 80},
                new Box { Id=2, Name = "Caixa 2", Height = 80, Width = 50, Depth = 40},
                new Box { Id=3, Name = "Caixa 3", Height = 50, Width = 80, Depth = 60}
            );
    }
}
