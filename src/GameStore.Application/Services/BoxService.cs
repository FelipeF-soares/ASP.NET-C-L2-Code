using GameStore.Application.Services.Interfaces;
using GameStore.Domain;
using GameStore.Infrastructure.GameStorePersistence.Interfaces;

namespace GameStore.Application.Services;

public class BoxService : IBoxService
{
    private readonly IGameStoreBoxPersist boxPersist;
    private readonly IGameStoreGeneralPersist generalPersist;

    public BoxService(IGameStoreBoxPersist boxPersist, IGameStoreGeneralPersist generalPersist)
    {
        this.boxPersist = boxPersist;
        this.generalPersist = generalPersist;
    }

    public async Task<List<Order>> BoxOrder(List<Order> orders)
    {
        try
        {
           var boxes = await boxPersist.GetAllBoxesAsync();
           for(int i = 0; i < orders.Count; i++)
            {
                var box = GetBestBox(orders[i].Dimensions, boxes);
                if (box != null) orders[i].BoxId = box.Id;
            }
            return orders;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar caixas");
        }
    }

    private Box? GetBestBox(Dimensions orderDimension, Box[] boxes)
    {

        foreach (var box in boxes.OrderBy(b => b.Dimensions.Volume))
        {
            if(box.Dimensions.Volume >= box.Dimensions.Volume)
                if (FitsIn(orderDimension, box.Dimensions)) return box;
        }
        return null;
    }

    public bool FitsIn(Dimensions other, Dimensions box)
    {
        var permutations = new List<(int H, int W, int D)>
        {
            (other.Height, other.Width, other.Depth),
            (other.Height, other.Depth, other.Width),
            (other.Width, other.Height, other.Depth),
            (other.Width, other.Depth, other.Height),
            (other.Depth, other.Height, other.Width),
            (other.Depth, other.Width, other.Height)
        };
        return permutations.Any(p =>
                    p.H <= box.Height &&
                    p.W <= box.Width &&
                    p.D <= box.Depth
        );
    }

    public async Task<Box[]> GetAllBoxes()
    {
        try
        {
            var boxes = await boxPersist.GetAllBoxesAsync();
            if (boxes == null) return null;
            return boxes;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar caixas");
        }
    }

    public async Task<bool> Update(int id,Box model)
    {
        try
        {
            var box = await boxPersist.GetBoxByIdAsync(id);
            if (box == null) throw new Exception("Caixa não existe");
            model.Id = box.Id;
            generalPersist.Update(model);
            return await generalPersist.SaveChangesAsync();
            
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar caixas");
        }
    }

    public async Task<Box> GetBoxById(int id)
    {
        try
        {
            return await boxPersist.GetBoxByIdAsync(id);
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar caixas");
        }
    }
}
