using GameStore.Application.Services.Interfaces;
using GameStore.Domain;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;

namespace GameStore.Application.Services;

public class OrderService : IOrderService
{
    private readonly IGameStoreGeneralPersist generalPersist;
    private readonly IGameStoreOrderPersist orderPersist;

    public OrderService(IGameStoreGeneralPersist generalPersist, IGameStoreOrderPersist orderPersist)
    {
        this.generalPersist = generalPersist;
        this.orderPersist = orderPersist;
    }
    public async Task<bool> AddOrder(Order model)
    {
        try
        {
            generalPersist.Add(model);
            return await generalPersist.SaveChangesAsync();
        }
            catch (Exception)
        {
            throw new Exception("Erro ao adicionar");
        }
    }

    public async Task<Order[]> GetAllOrderAsync()
    {
        try
        {
            var orders = await orderPersist.GetAllOrderAsync();
            if (orders == null) return null;

            return orders;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar as Order");
        }
    }

    public Task<Order> GetOrderById(int modelId)
    {
        try
        {
            var order = orderPersist.GetOrderByIdAsync(modelId);
            if (order == null) return null;
            return order;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar o Order");
        }
    }
}
