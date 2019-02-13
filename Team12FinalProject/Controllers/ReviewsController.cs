using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;
        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Employee,Manager")]
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> PendingIndex()
        {
            return View(await _context.Reviews.Where(a => a.Approve == Approve.Pending).ToListAsync());
        }
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> ApprovedIndex()
        {

            return View(await _context.Reviews.Where(a => a.Approve != Approve.Pending).Include(a => a.Book).Include(a => a.Approver).Include(a => a.Author).OrderByDescending(a => a.ApproveDate).ToListAsync());
        }
        [Authorize(Roles = "Employee,Manager")]
        //[Authorize(Roles = "Manager")]
        public IActionResult ApproveReview(int id)
        {
            Review approvedReview = _context.Reviews.FirstOrDefault(c => c.ReviewID == id);
            approvedReview.Approve = Approve.Yes;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            approvedReview.Approver = _context.Users.Find(userId);
            _context.Update(approvedReview);
            _context.SaveChanges();
            return RedirectToAction("PendingIndex");
        }
        [Authorize(Roles = "Employee,Manager")]
        //[Authorize(Roles = "Manager")]
        public IActionResult RejectReview(int id)
        {
            Review rejectedReview = _context.Reviews.FirstOrDefault(c => c.ReviewID == id);
            rejectedReview.Approve = Approve.No;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            rejectedReview.Approver = _context.Users.Find(userId);
            _context.Update(rejectedReview);
            _context.SaveChanges();
            return RedirectToAction("PendingIndex");

        }
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int id)
        {
            var query = from b in _context.Reviews
                        select b;
            List<Review> AllReviews = new List<Review>();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AppUser user = _context.Users.Find(userId);
            query = query.Where(o => o.Author.Email == user.Email);
            query = query.Where(o => o.Book.BookID == id);

            AllReviews = query.ToList();


            if (AllReviews.Any())
            {
                return View("Error", new string[] { "You already reviewed this book" });
            }

            List<OrderDetail> AllOrders = new List<OrderDetail>();
            var query2 = from e in _context.OrderDetails
                         select e;
            query2 = query2.Include(o => o.Order).Include(o => o.Book).Where(o => o.Order.AppUser.Email == user.Email).Where(o => o.Book.BookID == id);
            AllOrders = query2.ToList();

            if (!AllOrders.Any())

            {
                return View("Error", new string[] { "You have not bought this book.You cannot review this book" });
            }



            ViewBag.id = id;
            return View();
        }




        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult Create([Bind("ReviewID,Reviews, CustomerRating")] Review review, int id)
        {

            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                review.Author = _context.Users.Find(userId);

                review.Approve = Approve.Pending;
                review.ApproveDate = System.DateTime.Today;
                review.Book = _context.Books.FirstOrDefault(c => c.BookID == id);

                _context.Add(review);
                _context.SaveChanges();




                return RedirectToAction("Details", "Books", new { id = id });
            }


            return View(review);
        }
        [Authorize(Roles = "Employee,Manager")]
        //[Authorize(Roles = "Manager")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = _context.Reviews.FirstOrDefault(c => c.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Manager")]
        //[Authorize(Roles = "Manager")]
        public IActionResult Edit(int id, Review review)
        {

            
            if (ModelState.IsValid)
            {
                try
                {
                    Review dbReview = _context.Reviews.FirstOrDefault(c => c.ReviewID == review.ReviewID);

                    dbReview.Reviews = review.Reviews;


                    _context.Update(dbReview);
                    _context.SaveChanges();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("PendingIndex");
            }

            return View(review);


        }
        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}



