using OrdersBackend.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBackend.BL.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> AddOrderAsync(OrderDto order);
        Task<OrderDto> UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int orderId);
    }
}
