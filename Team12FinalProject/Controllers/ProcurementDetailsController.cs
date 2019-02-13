using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team12FinalProject.Models;
using Team12FinalProject.DAL;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public class ProcurementDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public ProcurementDetailsController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Orders/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You must specify an order to add!" });

            }
            List<ProcurementDetail> AllProcurementDetails = new List<ProcurementDetail>();
            var query2 = from e in _context.ProcurementDetails
                         select e;
            query2 = query2.Include(o => o.Book).Include(o => o.Procurement).Where(o => o.Procurement.Completed == false && o.Procurement.ProcurementType == ProcurementType.Manual && o.Book.BookID == id);
            AllProcurementDetails = query2.ToList();
            if (AllProcurementDetails.Any())
            {
                return View("Error", new string[] { "You already have this book in your reorder cart!" });
            }
            Procurement pro = _context.Procurements.OrderByDescending(p => p.ProcurementID)
                                      .FirstOrDefault(p => p.Completed == false);
            Book bo = _context.Books.FirstOrDefault(b => b.BookID == id);
            if (pro == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }

            ProcurementDetail pd = new ProcurementDetail() { Procurement = pro, Book = bo, BookPrice = bo.Cost };

            return View("Create", pd);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcurementDetail pd)
        {
            if (pd.Quantity == 0)
            {
                return RedirectToAction("EditOrder", "Procurements", new { id = pd.Procurement.ProcurementID });
            }

            else
            {
                Book bo = _context.Books.FirstOrDefault(b => b.BookID == pd.Book.BookID);
                pd.Book = bo;

                Procurement pro = _context.Procurements.Find(pd.Procurement.ProcurementID);
                pd.Procurement = pro;

                bo.Cost = pd.BookPrice;
                _context.Books.Update(bo);
                _context.SaveChanges();

                pd.ExtendedPrice = pd.Quantity * pd.BookPrice;

                if (ModelState.IsValid)
                {
                    _context.ProcurementDetails.Add(pd);
                    _context.SaveChanges();
                    return RedirectToAction("EditOrder", "Procurements", new { id = pd.Procurement.ProcurementID });
                }
                return View(pd);
            }

        }

        // GET: OrderDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProcurementDetail pd = _context.ProcurementDetails.Include(p => p.Book).FirstOrDefault(p => p.ProcurementDetailID == id);
            if (pd == null)
            {
                return NotFound();
            }
            return View(pd);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProcurementDetail pd)
        {
            if (ModelState.IsValid)
            {
                //Find the related registration detail in the database
                ProcurementDetail DbProDet = _context.ProcurementDetails
                                                     .Include(r => r.Book)
                                                     .Include(r => r.Procurement)
                                                     .FirstOrDefault(r => r.ProcurementDetailID ==
                                                                     pd.ProcurementDetailID);

                //update the related fields
                DbProDet.Quantity = pd.Quantity;
                DbProDet.BookPrice = pd.BookPrice;
                DbProDet.ExtendedPrice = DbProDet.BookPrice * DbProDet.Quantity;

                Book DbBo = _context.Books.FirstOrDefault(b => b.BookID == DbProDet.Book.BookID);
                DbBo.Cost = pd.BookPrice;
                _context.Books.Update(DbBo);
                _context.SaveChanges();


                _context.ProcurementDetails.Update(DbProDet);
                _context.SaveChanges();
                //return to the order details
                return RedirectToAction("EditOrder", "Procurements", new { id = DbProDet.Procurement.ProcurementID });
            }
            return View(pd);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pd = await _context.ProcurementDetails
                                   .FirstOrDefaultAsync(m => m.ProcurementDetailID == id);
            if (pd == null)
            {
                return NotFound();
            }

            return View(pd);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pd = await _context.ProcurementDetails.FindAsync(id);
            Procurement pro = _context.Procurements.FirstOrDefault(r => r.ProcurementDetails.Any(p => p.ProcurementDetailID == id));
            _context.ProcurementDetails.Remove(pd);
            await _context.SaveChangesAsync();
            return RedirectToAction("EditOrder", "Procurements", new { id = pro.ProcurementID });
        }

        private bool PorcurementDetailExists(int id)
        {
            return _context.ProcurementDetails.Any(e => e.ProcurementDetailID == id);
        }

    }
}