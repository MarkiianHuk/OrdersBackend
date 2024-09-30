using OrdersBackend.BL.Dtos;
using OrdersBackend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBackend.BL.Mappers
{
    public class OrderMapper
    {
        public static IEnumerable<OrderDto> FromEntitiesToModels(IEnumerable<Order> entities)
        {
            return new List<OrderDto>(entities.Select(FromEntityToModel));
        }

        public static OrderDto FromEntityToModel(Order entity)
        {
            return new OrderDto()
            {
                Id = entity.Id,
                Quantity = entity.Quantity,
                Price = entity.Price,
                UnitCurrency = entity.UnitCurrency,
                OutputCurrency = entity.OutputCurrency
            };
        }

        public static IEnumerable<Order> FromModelsToEntities(IEnumerable<OrderDto> models)
        {
            return new List<Order>(models.Select(FromModelToEntity));
        }

        public static Order FromModelToEntity(OrderDto model)
        {
            return new Order()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Price = model.Price,
                UnitCurrency = model.UnitCurrency,
                OutputCurrency = model.OutputCurrency
            };
        }
    }
}
