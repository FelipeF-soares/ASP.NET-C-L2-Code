using GameStore.Domain;

namespace GameStore.Infrastructure.GameStorePersistence.Interfaces;

public interface IGameStoreOrderPersist
{
    Task<Order[]> GetAllOrderAsync();
    Task<Order> GetOrderByIdAsync(int orderId);
}
