using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Business;
using RestaurantOrder.Models;
using RestaurantOrder.Utils;

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

        [HttpGet]
        public JsonResult GetOrderOutput(string input)
        {
            var orderParams = input.Split(',');

            try
            {
                return Json(new OrderUtils().GetOrderOutput(orderParams));
            }
            catch (Exception)
            {
                return Json("Invalid request.");
            }
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
                //order.Output = GetOrderOutput(order.Input);

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
            _orderManager.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
