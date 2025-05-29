using GameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Interfaces;

public interface IBoxService
{
    Task<Box[]> GetAllBoxes();
    Task<Box> GetBoxById(int id);

    Task<bool> Update(int id,Box model);

    Task<List<Order>> BoxOrder(List<Order> orders);

}
