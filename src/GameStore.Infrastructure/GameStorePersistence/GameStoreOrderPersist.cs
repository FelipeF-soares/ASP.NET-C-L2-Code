using GameStore.Domain;
using GameStore.Infrastructure.ApplicationContext;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.GameStorePersistence;

public class GameStoreOrderPersist : IGameStoreOrderPersist
{
    private readonly GameStoreDbContext context;

    public GameStoreOrderPersist(GameStoreDbContext context)
    {
        this.context = context;
    }
    public async Task<Order[]> GetAllOrderAsync()
    {
        IQueryable<Order> query = context.Orders
                                         .Include(order => order.Products)
                                         .Include(order => order.Box)
                                         .AsNoTracking();
        return await query.ToArrayAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        IQueryable<Order> query = context.Orders
                                         .Where(order => order.Id == orderId)
                                         .Include(order => order.Products)
                                         .Include(order => order.Box)
                                         .AsNoTracking();
        return await query.FirstAsync();
    }
}
