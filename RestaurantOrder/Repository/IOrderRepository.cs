using RestaurantOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.Repository
{
    public interface IOrderRepository: IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int id);
        void InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        void Save();
    }
}
