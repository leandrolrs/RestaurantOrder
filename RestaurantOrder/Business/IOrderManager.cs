using RestaurantOrder.Models;
using System.Collections.Generic;

namespace RestaurantOrder.Business
{
    public interface IOrderManager
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int id);
        void InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
    }
}
