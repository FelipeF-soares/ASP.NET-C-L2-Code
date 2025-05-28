using GameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Interfaces;

public interface IOrderService
{
    Task<bool> AddOrder(Order model);
    Task<Order[]> GetAllOrderAsync();
    Task<Order> GetOrderById(int modelId);
}
