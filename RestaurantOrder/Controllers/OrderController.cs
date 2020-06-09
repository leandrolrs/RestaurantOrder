using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Models;

namespace RestaurantOrder.Controllers
{
    public class OrderController : Controller
    {

        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderHistories.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new OrderHistory());
            else
                return View(_context.OrderHistories.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Input,Output")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                if (orderHistory.Id == 0)
                    _context.Add(orderHistory);
                else
                    _context.Update(orderHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderHistory);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.OrderHistories.FindAsync(id);
            _context.OrderHistories.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
