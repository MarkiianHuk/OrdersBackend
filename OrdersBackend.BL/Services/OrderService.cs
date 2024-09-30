using OrdersBackend.BL.Dtos;
using OrdersBackend.BL.Interfaces;
using OrdersBackend.BL.Mappers;
using OrdersBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBackend.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Serilog.ILogger _logger;

        public OrderService(IOrderRepository orderRepository, Serilog.ILogger logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return OrderMapper.FromEntitiesToModels(orders).ToList();
        }

        public async Task<OrderDto> AddOrderAsync(OrderDto order)
        {
            var orderToCreate = OrderMapper.FromModelToEntity(order);

            await _orderRepository.AddAsync(orderToCreate);
            order.Id = orderToCreate.Id;

            return order;
        }

        public async Task<OrderDto> UpdateOrderAsync(OrderDto order)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(order.Id);

            if (existingOrder is null)
            {
                _logger.Error("No Order found");
                throw new ArgumentException("No Order found");
            }

            existingOrder.Price = order.Price;
            existingOrder.Quantity = order.Quantity;
            existingOrder.UnitCurrency = order.UnitCurrency;
            existingOrder.OutputCurrency = order.OutputCurrency;

            await _orderRepository.UpdateAsync(existingOrder);

            return OrderMapper.FromEntityToModel(existingOrder);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);

            if (existingOrder is null)
            {
                _logger.Error("No Order found");
                throw new ArgumentException("No Order found");
            }

            await _orderRepository.DeleteAsync(existingOrder);
        }
    }
}
