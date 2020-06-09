using RestaurantOrder.Domain;
using RestaurantOrder.Enumerations;
using RestaurantOrder.Models;
using RestaurantOrder.Repository;
using RestaurantOrder.Rules;
using RestaurantOrder.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantOrder.Business
{
    public class OrderManager: IOrderManager
    {


        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public Order GetOrderByID(int id)
        {
            return _orderRepository.GetOrderByID(id);
        }

        public void InsertOrder(Order order)
        {
            _orderRepository.InsertOrder(order);
            _orderRepository.Save();
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
            _orderRepository.Save();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
            _orderRepository.Save();
        }

    }
}
