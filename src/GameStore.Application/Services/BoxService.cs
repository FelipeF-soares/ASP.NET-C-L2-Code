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
            var listOrders = new List<Order>();
            
            foreach (var order in orders)
            {
                var listBox = new List<Box>();
                var box = await GetBestBox(order, boxes);
                if (box != null)
                {
                    listBox.Add(box);
                    order.Boxes = listBox;
                    listOrders.Add(order);
                }
                else
                {
                    var itens = order.Products.Count;
                    if (itens <= 1)
                    {
                        listBox.Add(box);
                        order.Boxes = listBox;
                        listOrders.Add(order);
                    }
                    else
                    {
                        var firstPart = order.Products.Take(itens / 2).ToList();
                        var firstOrder = new Order();
                        firstOrder.Products = firstPart;
                        var secondPart = order.Products.Skip(itens / 2).ToList();
                        var secondOrder = new Order();

                        firstOrder.Products = secondPart;
                        box = await GetBestBox(firstOrder, boxes);
                        listBox.Add(box);
                        order.Boxes = listBox;
                        listOrders.Add(order);

                        box = await GetBestBox(secondOrder, boxes);
                        listBox.Add(box);
                        order.Boxes = listBox;
                        listOrders.Add(order);
                    }
                }
            }
            return listOrders;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao carregar caixas");
        }
    }

    private async Task<Box> GetBestBox(Order orderDimension, Box[] boxes)
    {
        Dimensions dimensions = new Dimensions();
        dimensions.Width = orderDimension.Width;
        dimensions.Height = orderDimension.Width;
        dimensions.Depth = orderDimension.Depth;
        dimensions.Volume = orderDimension.Volume;

        var emptyBox = await boxPersist.GetBoxByIdAsync(99);
        foreach (var box in boxes.OrderBy(b => b.Volume))
        {
            Dimensions dimensionsBox = new Dimensions();
            dimensionsBox.Width = box.Width;
            dimensionsBox.Height = box.Width;
            dimensionsBox.Depth = box.Depth;
            dimensionsBox.Volume = box.Volume;

            if (FitsIn(orderDimension, dimensionsBox)) return box;

        }
        return emptyBox;
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
