using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Team12FinalProject.Controllers
{
    public class ReportsController : Controller
    {
        private AppDbContext _db;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ReportsController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllBooksSold(int SelectedSort)
        {
            ViewBag.AllFilters = GetAllBookSort();
            var query = from v in _db.OrderDetails
                        select v;

            query = query.Include(o => o.Book).ThenInclude(o => o.ProcurementDetails).Include(o => o.Order).ThenInclude(o => o.AppUser).Where(o=>o.Order.CheckOutStatus == true);
            ViewBag.Record = query.ToList().Count;

            if (SelectedSort == 0)
            {
                return View(query.OrderByDescending(o => o.Order.OrderDate).ToList());
            }
            else if (SelectedSort == 1)
            {
                List<OrderDetail> od = query.ToList();
                var sortquery = from v in od select v;
                sortquery = sortquery.OrderByDescending(o => o.Book.Profit).ToList();

                return View(sortquery);
            }
            else if (SelectedSort == 2)
            {
                List<OrderDetail> od = query.ToList();
                var sortquery = from v in od select v;
                sortquery = sortquery.OrderBy(o => o.Book.Profit).ToList();

                return View(sortquery);
                //return View(query.Include(o => o.Book).ThenInclude(o => o.ProcurementDetails).OrderBy(o => o.Book.Profit).ToList());
            }
            else if (SelectedSort == 3)
            {
                return View(query.OrderByDescending(o => o.BookPrice).ToList());
            }
            else if (SelectedSort == 4)
            {
                return View(query.OrderBy(o => o.BookPrice).ToList());
            }
            else
            {
                return View(query.OrderByDescending(o => o.Quantity).ToList());
            }

        }

        public async Task<ActionResult> AllCustomers(int SelectedSort)
        {
            //ViewBag.AllFilters = GetAllCustomerSort();
            //List<AppUser> alluser = new List<AppUser>();
            //foreach (AppUser user in _userManager.Users)
            //{
            //    var list = await _userManager.IsInRoleAsync(user, "Customer");
            //    alluser.Add(user);
            //}
            ViewBag.AllFilters = GetAllCustomerSort();
            var alluser = _userManager.GetUsersInRoleAsync("Customer").Result.ToList();
            int count = alluser.Count;

            List<AppUser> customer = new List<AppUser>();
            var query = from c in _db.AppUsers
                        select c;
            customer = query.Include(o => o.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(o => o.Book).ThenInclude(o => o.ProcurementDetails).ToList();
            List<AppUser> finalcustomer = new List<AppUser>();
            foreach (AppUser c in customer)
            {
                foreach(AppUser u in alluser )
                {
                    if(c.UserName == u.UserName)
                    {
                        finalcustomer.Add(c);
                    }
                }
            }

            ViewBag.Record = finalcustomer.Count;
            
            if (SelectedSort == 0)
            {
                
                var sortquery = from v in finalcustomer select v;
                sortquery = sortquery.OrderByDescending(o => o.CustomerProfit).ToList();

                return View(sortquery);
                
            }
            else if (SelectedSort == 1)
            {
                var sortquery = from v in finalcustomer select v;
                sortquery = sortquery.OrderBy(o => o.CustomerProfit).ToList();

                return View(sortquery);
            }
            else if (SelectedSort == 2)
            {
                var sortquery = from v in finalcustomer select v;
                sortquery = sortquery.OrderByDescending(o => o.Revenue).ToList();

                return View(sortquery);
            }
            else if (SelectedSort == 3)
            {
                var sortquery = from v in finalcustomer select v;
                sortquery = sortquery.OrderBy(o => o.Revenue).ToList();

                return View(sortquery);
            }






            return View(); 
        }

        public IActionResult AllOrders(int SelectedSort)
        {
            ViewBag.AllFilters = GetAllOrderSort();
            var query = from c in _db.Orders
                         select c;
            query = query.Include(o => o.OrderDetails).ThenInclude(o=>o.Book).ThenInclude(o => o.ProcurementDetails).Include(o => o.AppUser)
                .Where(o => o.CheckOutStatus == true);
            
            ViewBag.Record = query.ToList().Count;
            List<Order> order = query.ToList();

            

            //odquery = odquery.Include(o => o.OrderDetails).ThenInclude(o => o.Book).ThenInclude(o => o.ProcurementDetails).Include(o => o.AppUser);


            if (SelectedSort == 0)
            {
                return View(query.OrderByDescending(o => o.OrderDate).ToList());
            }
            else if (SelectedSort == 1)
            {
                List<Order> oo = query.ToList();
                var sortquery = from v in oo select v;
                sortquery = sortquery.OrderByDescending(o => o.OrderProfit).ToList();
                return View(sortquery);
            }
            else if (SelectedSort == 2)
            {
                List<Order> oo = query.ToList();
                var sortquery = from v in oo select v;
                sortquery = sortquery.OrderBy(o => o.OrderProfit).ToList();
                return View(sortquery);
            }
            else if (SelectedSort == 3)
            {
                List<Order> oo = query.ToList();
                var sortquery = from v in oo select v;
                sortquery = sortquery.OrderByDescending(o => o.Revenue).ToList();
                return View(sortquery);
            }
            else 
            {
                List<Order> oo = query.ToList();
                var sortquery = from v in oo select v;
                sortquery = sortquery.OrderBy(o => o.OrderProfit).ToList();
                return View(sortquery);
            }
            
        }

        public IActionResult ApprovedOrRejectedReview(int SelectedSort)
        {
            ViewBag.AllFilters = GetAllReviewsSorts();
            var admins = _userManager.GetUsersInRoleAsync("Employee").Result.ToList();

            var admins2 = _userManager.GetUsersInRoleAsync("Manager").Result.ToList();
            List<AppUser> emp = new List<AppUser>().ToList();
            


            foreach (AppUser user in admins)
            {
                var query = from v in _db.Reviews
                            select v;
                query = query.Where(o => o.Approver == user);

                List<Review> reviewApproved = query.Where(o => o.Approve == Approve.Yes).ToList();
                List<Review> reviewRej = query.Where(o => o.Approve == Approve.No).ToList();
                user.myApprovedReviews = reviewApproved.Count;
                user.myRejectedReviews = reviewRej.Count;
                emp.Add(user);

            }

            foreach (AppUser user in admins2)
            {
                var query = from v in _db.Reviews
                            select v;
                query = query.Where(o => o.Approver == user);

                List<Review> reviewApproved = query.Where(o => o.Approve == Approve.Yes).ToList();
                List<Review> reviewRej = query.Where(o => o.Approve == Approve.No).ToList();
                user.myApprovedReviews = reviewApproved.Count;
                user.myRejectedReviews = reviewRej.Count;
                emp.Add(user);

            }



            ViewBag.Record = emp.Count;
            var sort = from c in emp
                       select c;


            if (SelectedSort == 1)
            {
                return View(sort.OrderByDescending(o=>o.myApprovedReviews).ToList());
            }
            else if (SelectedSort == 2)
            {
                return View(sort.OrderBy(o => o.myApprovedReviews).ToList());
            }
            else if(SelectedSort ==3)
            {
                return View(sort.OrderByDescending(o => o.myRejectedReviews).ToList());
            }
            else if(SelectedSort==4)
            {
                return View(sort.OrderBy(o => o.myRejectedReviews).ToList());
            }
            else
            {
                return View(sort.OrderBy(o => o.Email).ToList());
            }

        }

        public IActionResult CurrentInventory()
        {
            var query = from v in _db.Books
                        select v;
            query = query.Include(o => o.ProcurementDetails);
            Decimal Total = query.Sum(o => o.CopiesOnHand * o.AvgCost);
            ViewBag.Total = String.Format("{0:C}", Total);
            ViewBag.Record = query.ToList().Count;
            return View(query.ToList());
        }

        public IActionResult Totals()
        {
            

            var query = from v in _db.Orders
                        select v;


            query = query.Include(o => o.OrderDetails).ThenInclude(o => o.Book).ThenInclude(o => o.ProcurementDetails);
            List<Order> ord = query.ToList();
            var calquery = from v in ord
                           select v;
            Decimal Revenue = calquery.Sum(o => o.Revenue);
            ViewBag.Revenue = String.Format("Order Total: {0:C}", Revenue);
            Decimal Cost = calquery.Sum(o => o.Cost);
            ViewBag.Cost = String.Format("Order Total: {0:C}", Cost);
            Decimal Profit = calquery.Sum(o => o.OrderProfit);
            ViewBag.Profit = String.Format("Order Total: {0:C}", Profit);
            return View("Totals","Reports");
        } 

        public SelectList GetAllReviewsSorts()
        {
            List<SelectListItem> Filters = new List<SelectListItem>();
            Filters.Add(new SelectListItem() { Text = "Email", Value = "0" });
            Filters.Add(new SelectListItem() { Text = "Most Number of Approved Reviews", Value = "1" });
            Filters.Add(new SelectListItem() { Text = "Least Number of Approved Reviews", Value = "2" });
            Filters.Add(new SelectListItem() { Text = "Most Number of Rejected Reviews", Value = "3" });
            Filters.Add(new SelectListItem() { Text = "Least Number of Rejected Reviews", Value = "4" });


            SelectList AllFilters = new SelectList(Filters, "Value", "Text");
            return AllFilters;
        }

        public SelectList GetAllBookSort()
        {
            List<SelectListItem> Filters = new List<SelectListItem>();
            Filters.Add(new SelectListItem() { Text = "Most Recent", Value = "0" });
            Filters.Add(new SelectListItem() { Text = "Most Profitable", Value = "1" });
            Filters.Add(new SelectListItem() { Text = "Least Profitable", Value = "2" });
            Filters.Add(new SelectListItem() { Text = "Most Expensive", Value = "3" });
            Filters.Add(new SelectListItem() { Text = "Least Expensive", Value = "4" });
            Filters.Add(new SelectListItem() { Text = "Most Popular", Value = "5" });


            SelectList AllFilters = new SelectList(Filters, "Value", "Text");
            return AllFilters;

        }

        public SelectList GetAllCustomerSort()
        {
            List<SelectListItem> Filters = new List<SelectListItem>();
            Filters.Add(new SelectListItem() { Text = "Most Profit", Value = "0" });
            Filters.Add(new SelectListItem() { Text = "Least Profit", Value = "1" });
            Filters.Add(new SelectListItem() { Text = "Most Revenue", Value = "2" });
            Filters.Add(new SelectListItem() { Text = "Least Revenue", Value = "3" });



            SelectList AllFilters = new SelectList(Filters, "Value", "Text");
            return AllFilters;

        }
        public SelectList GetAllOrderSort()
        {
            List<SelectListItem> Filters = new List<SelectListItem>();
            Filters.Add(new SelectListItem() { Text = "Most Recent", Value = "0" });
            Filters.Add(new SelectListItem() { Text = "Most Profit", Value = "1" });
            Filters.Add(new SelectListItem() { Text = "Least Profit", Value = "2" });
            Filters.Add(new SelectListItem() { Text = "Most Revenue", Value = "3" });
            Filters.Add(new SelectListItem() { Text = "Least Revenue", Value = "4" });



            SelectList AllFilters = new SelectList(Filters, "Value", "Text");
            return AllFilters;

        }
    }
}
