using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrder.Repository
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context  = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderByID(int id)
        {
            return _context.Orders.Find(id);
        }

        public void InsertOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
