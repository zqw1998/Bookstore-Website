using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
//using Team12FinalProject.Utilities;

namespace Team12FinalProject.Controllers
{
    public class ProcurementsController : Controller
    {
        private readonly AppDbContext _context;
        public ProcurementsController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            List<Book> books = new List<Book>();
            books = _context.Books.Include(b => b.ProcurementDetails).ThenInclude(b => b.Procurement).ThenInclude(b => b.AppUser)
                            .Where(b => b.QuantityOnOrder != 0).ToList();



            return View(books);
        }



        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Specify an order to view!" });
            }
            Procurement procurement = _context.Procurements
                                              .Include(o => o.AppUser)
                                              .Include(o => o.ProcurementDetails).ThenInclude(o => o.Book)
                                              .FirstOrDefault(o => o.ProcurementID == id);

            //make sure a customer isn't trying to look at someone else's order
            if (User.IsInRole("Manager") == false)
            {
                return View("Error", new string[] { "You are not authorized to view this order!" });
            }

            if (procurement == null)
            {
                return View("Error", new string[] { "Order was not found" });
            }
            return View(procurement);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procurement procurement, ProcurementType SelectedType)
        {
            procurement.ProcurementDate = System.DateTime.Today;
            procurement.Completed = false;
            if (SelectedType == ProcurementType.Manual)
            {
                procurement.ProcurementType = ProcurementType.Manual;
            }
            else
            {
                procurement.ProcurementType = ProcurementType.Automatic;
            }



            if (procurement.ProcurementType == ProcurementType.Manual)
            {
                if (ModelState.IsValid)
                {
                    Procurement alreadyexist = _context.Procurements.Where(p => p.ProcurementType == ProcurementType.Manual).FirstOrDefault(p => p.Completed == false);
                    if (alreadyexist == null)
                    {
                        _context.Add(procurement);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("EditOrder", new { id = procurement.ProcurementID });

                    }
                    else
                    {
                        ViewBag.ExistingOrder = "This is your existing order.";
                        return RedirectToAction("EditOrder", new { id = alreadyexist.ProcurementID });
                    }
                }
            }

            if (procurement.ProcurementType == ProcurementType.Automatic)
            {
                List<Book> books = new List<Book>();
                books = _context.Books.Include(b => b.ProcurementDetails).Where(b => b.Inventory < b.Reorder).ToList();
                if (books.Count == 0)
                {
                    return View("Error", new string[] { "There are currently no books below reorder point." });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(procurement);
                        await _context.SaveChangesAsync();
                        foreach (Book b in books)
                        {
                            ProcurementDetail procurementDetail = new ProcurementDetail();
                            procurementDetail.Quantity = 5;
                            procurementDetail.BookPrice = b.Cost;
                            procurementDetail.ExtendedPrice = procurementDetail.Quantity * procurementDetail.BookPrice;
                            procurementDetail.Book = _context.Books.FirstOrDefault(o => o.BookID == b.BookID);
                            procurementDetail.Procurement = _context.Procurements.FirstOrDefault(p => p.ProcurementID == procurement.ProcurementID);

                            _context.Add(procurementDetail);
                            await _context.SaveChangesAsync();
                        }
                        return RedirectToAction("EditOrder", new { id = procurement.ProcurementID });
                    }
                }


            }
            return View("Create");
        }

        public IActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You need to specify an order id" });
            }
            Procurement pro = _context.Procurements.Include(p => p.ProcurementDetails).ThenInclude(p => p.Book)
                                              .FirstOrDefault(p => p.ProcurementID == id);

            if (pro == null)
            {
                return RedirectToAction("Index");
            }

            return View(pro);
        }

        //change the procurement status and 
        public IActionResult ReorderConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You need to specify an order id" });
            }
            Procurement pro = _context.Procurements.Include(p => p.ProcurementDetails).ThenInclude(p => p.Book)
                                              .FirstOrDefault(p => p.ProcurementID == id);

            if (pro == null)
            {
                return RedirectToAction("Index");
            }

            AppUser user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            pro.AppUser = user;

            pro.Completed = true;
            _context.Procurements.Update(pro);
            _context.SaveChanges();

            foreach (ProcurementDetail pd in pro.ProcurementDetails)
            {
                Book bo = _context.Books.Include(b => b.ProcurementDetails).FirstOrDefault(b => b.BookID == pd.Book.BookID);
                bo.QuantityOnOrder = bo.QuantityOnOrder + pd.Quantity;

                _context.Books.Update(bo);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: Orders
        public ActionResult ProcurementList()
        {
            List<Procurement> procurements = new List<Procurement>();
            procurements = _context.Procurements.Include(o => o.ProcurementDetails).Include(o => o.AppUser).ToList();

            return View(procurements);
        }

        //GET: Procurement/CheckIn
        public IActionResult CheckIn(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You need to specifiy which book to check in" });
            }

            Book b = _context.Books.FirstOrDefault(o => o.BookID == id);

            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }

        //POST: Procurement/CheckIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckIn(Book b, Int32 CopiesArrived)
        {
            Book bo = _context.Books.FirstOrDefault(o => o.BookID == b.BookID);
            if (CopiesArrived > bo.QuantityOnOrder)
            {
                ViewBag.ErrorMessage = "The copies checked in should be less than the quantity you ordered";
                return View(b);
            }
            else
            {
                bo.QuantityOnOrder = bo.QuantityOnOrder - CopiesArrived;
                bo.CopiesOnHand = bo.CopiesOnHand + CopiesArrived;
                _context.Books.Update(bo);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }

    }
}