using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.HelpersFunctions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> AddAsync(Order order)
        {
            _orderRepository.Add(order);
            await _orderRepository.SavechangesAsync();

            return order;

        }
        public async Task<Order> DeleteAsync(Order order)
        {
            var userLooked = await _orderRepository.GetByIdAsync(order.OrderId);

            if (userLooked is null)
            {
                throw new NotFoundException("This Order does not exist");
            }
            _orderRepository.DeleteAsync(userLooked);
            await _orderRepository.SavechangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders is null)
            {
                throw new NotFoundException("There are no registered Order yet");
            }
            return orders;
        }
        public async Task<Order?> GetByIdAsync(int Id)
        {
            var order = await _orderRepository.GetByIdAsync(Id);

            if (order is null)
            {
                throw new NotFoundException("The user does not exist");
            }

            return order;
        }

        public async Task<Order?> GetOrderByNameAsync(string OrderName)
        {
            var order = await _orderRepository.GetOrderByNameAsync(OrderName);

            if (order is null)
            {
                throw new NotFoundException("The order does not exist");
            }

            return order;
        }

        public Task SavechangesAsync()
        {
            return _orderRepository.SavechangesAsync();
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var userLooked = await _orderRepository.GetOrderByNameAsync(order.OrderName);

            if (userLooked is null)
            {
                throw new NotFoundException("The order does not exist");
            }

            userLooked.OrderName = order.OrderName;
            userLooked.NumberOfUnits = order.NumberOfUnits;
            userLooked.UnitPrice = order.UnitPrice;
            userLooked.TotalPrice = order.TotalPrice;
            userLooked.OrderStatus = order.OrderStatus;
            userLooked.OrderDate = OrderHelperFunctions.SetOrderDateOnUpdate();

            _orderRepository.UpdateAsync(userLooked);
            await _orderRepository.SavechangesAsync();

            return order;
        }
    }
}
