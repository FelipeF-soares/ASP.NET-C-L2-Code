using GameStore.Domain;

namespace GameStore.Infrastructure.GameStorePersistence.Interfaces;

public interface IGameStoreBoxPersist
{
    Task<Box[]> GetAllBoxesAsync();
    Task<Box> GetBoxByIdAsync(int id);
}
