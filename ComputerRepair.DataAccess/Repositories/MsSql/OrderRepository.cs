using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Repositories.MsSql
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ComputerRepairContext _computerRepairContext;
        public OrderRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }

       public void Add(Order order)
        {
            _computerRepairContext.Add(order);
        }

        public void DeleteAsync(Order order)
        {
            _computerRepairContext.Remove(order);
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _computerRepairContext.Orders
                   .AsNoTracking()
                   .ToListAsync();
        }

        public Task<Order?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.Orders
              .Where(u => u.OrderId == Id)
              .AsNoTracking()
              .FirstOrDefaultAsync();
        }

        public Task<Order?> GetOrderByNameAsync(string OrderName)
        {
            return _computerRepairContext.Orders
              .Where(u => u.OrderName == OrderName)
              .AsNoTracking()
              .FirstOrDefaultAsync();
        }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
        }

        public void UpdateAsync(Order order)
        {
            _computerRepairContext.Update(order);
        }

 
    }
}
