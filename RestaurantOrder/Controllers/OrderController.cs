using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Business;
using RestaurantOrder.Models;

namespace RestaurantOrder.Controllers
{

    public class OrderController : Controller
    {

        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public IActionResult Index()
        {
            return View(_orderManager.GetOrders().ToList());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Order());
            else
                return View(_orderManager.GetOrderByID(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit([Bind("Id,Input,Output")] Order order)
        {
            if (ModelState.IsValid)
            {
                var orderParams = order.Input.Split(',');

                try
                {
                    order.Output = _orderManager.GetOrderOutput(orderParams);
                }
                catch (Exception)
                {
                    order.Output = "Invalid request.";
                }

                if (order.Id == 0)
                    _orderManager.InsertOrder(order);
                else
                    _orderManager.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var employee = _orderManager.GetOrderByID(id);
            _orderManager.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
