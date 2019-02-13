using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Team12FinalProject.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderDetail orderDetail)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.LowStock = "The book in stock is less than the amount you ordered.";
                return View(orderDetail);
            }


            //Find the related registration detail in the database
            OrderDetail DbOrderDetail = _context.OrderDetails
                                        .Include(r => r.Book)
                                        .Include(r => r.Order)
                                        .FirstOrDefault(r => r.OrderDetailID ==
                                                            orderDetail.OrderDetailID);

            if (orderDetail.Quantity > DbOrderDetail.Book.CopiesOnHand)
            {
                return View(orderDetail);
            }

            //update the related fields
            DbOrderDetail.Quantity = orderDetail.Quantity;
            DbOrderDetail.BookPrice = DbOrderDetail.Book.Price;
            

            //update the database
            _context.OrderDetails.Update(DbOrderDetail);
            _context.SaveChanges();

            //return to the order details
            return RedirectToAction("Details", "Orders", new { id = DbOrderDetail.Order.OrderID });
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);

            int id2 = orderDetail.Order.OrderID;
            _context.OrderDetails.Remove(orderDetail);
            // var orderDetail = await _context.OrderDetails.FindAsync(id);
            // _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = id2 });
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}