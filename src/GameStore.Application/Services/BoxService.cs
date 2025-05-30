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
            var boxDefault = await boxPersist.GetBoxByIdAsync(99);
            var listOrders = new List<Order>();

            foreach (var order in orders)
            {
                var listBox = new List<Box>();
                var box = await GetBestBox(order, boxes);
                if (box.Id != 99)
                {
                    foreach(var product in order.Products)
                    {
                        product.BoxId = box.Id;
                    }
                    listBox.Add(box);
                    order.Boxes = listBox;
                    listOrders.Add(order);

                }
                else
                {
                    var itens = order.Products.Count;
                    if (itens <= 1)
                    {
                        listBox.Add(boxDefault);
                        order.Boxes = listBox;
                        listOrders.Add(order);
                    }
                    else
                    {
                        
                        var firstPart = order.Products.Take(itens / 2).ToList();
                        var firstOrder = new Order();
                        firstOrder.Products = firstPart;
                        box = await GetBestBox(firstOrder, boxes);
                        foreach(var p in firstPart)
                        {
                            p.BoxId = box.Id;
                        }
                        listBox.Add(box);
                        
                        var secondPart = order.Products.Skip(itens / 2).ToList();
                        var secondOrder = new Order();
                        secondOrder.Products = secondPart;
                        box = await GetBestBox(secondOrder, boxes);
                        foreach (var p in secondPart)
                        {
                            p.BoxId = box.Id;
                        }
                        var listbox2 = new List<Box>();
                        listbox2.Add(box);
                        var t = listBox.Concat(listbox2).ToList();
                        order.Boxes = t;
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
        var dimensions = CalculateOrderDimensions(orderDimension);

        foreach (var box in boxes.OrderBy(b => b.Volume))
        {
            var boxDimensions = new Dimensions
            {
                Width = box.Width,
                Height = box.Height,
                Depth = box.Depth,
                Volume = box.Volume
            };

            if (FitsIn(dimensions, boxDimensions))
                return box;
        }

        return await boxPersist.GetBoxByIdAsync(99);
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
    private Dimensions CalculateOrderDimensions(Order order)
    {
        var totalVolume = order.Products.Sum(p => p.Width * p.Height * p.Depth);
        return new Dimensions
        {
            Width = order.Products.Max(p => p.Width),
            Height = order.Products.Sum(p => p.Height),
            Depth = order.Products.Max(p => p.Depth),
            Volume = totalVolume
        };
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
