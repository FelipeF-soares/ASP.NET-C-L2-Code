using GameStore.Infrastructure.ApplicationContext;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;

namespace GameStore.Infrastructure.GameStorePersistence;

public class GameStoreGeneralPersist : IGameStoreGeneralPersist
{
    private readonly GameStoreDbContext context;

    public GameStoreGeneralPersist(GameStoreDbContext context)
    {
        this.context = context;
    }
    public void Add<T>(T entity) where T : class
    {
        context.Add(entity);
    }
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
    public void Update<T>(T entity) where T : class
    {
        context.Update(entity);
    }
}
