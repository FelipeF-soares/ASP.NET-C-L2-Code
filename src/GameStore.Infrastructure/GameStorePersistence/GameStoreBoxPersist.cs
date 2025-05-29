using GameStore.Domain;
using GameStore.Infrastructure.ApplicationContext;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.GameStorePersistence;

public class GameStoreBoxPersist : IGameStoreBoxPersist
{
    private readonly GameStoreDbContext context;

    public GameStoreBoxPersist(GameStoreDbContext context)
    {
        this.context = context;
    }
    public Task<Box[]> GetAllBoxesAsync()
    {
        IQueryable<Box> query = context.Boxes;
        
        return query.ToArrayAsync();
    }

    public async Task<Box> GetBoxByIdAsync(int id)
    {
        var boxes = context.Boxes;
        return await boxes.FirstOrDefaultAsync(box => box.Id == id);
    }
}
