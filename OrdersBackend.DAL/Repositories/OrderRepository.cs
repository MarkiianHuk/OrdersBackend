using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersBackend.DAL.Interfaces;
using OrdersBackend.DAL.Models;

namespace OrdersBackend.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == orderId);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            var entry = _context.Entry(order);

            if (entry.State == EntityState.Detached)
            {
                _context.Orders.Attach(order);
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            var entry = _context.Entry(order);

            if (entry.State == EntityState.Detached)
            {
                _context.Orders.Attach(order);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
