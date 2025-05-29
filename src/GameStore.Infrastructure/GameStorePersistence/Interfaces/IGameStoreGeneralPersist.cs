using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.GameStorePersistence.Interfaces;

public interface IGameStoreGeneralPersist
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();
}
