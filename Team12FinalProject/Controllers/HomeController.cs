using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Team12FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private AppDbContext _db;

        public HomeController(AppDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {

            if (User.IsInRole("Customer") && _db.Orders.FirstOrDefault(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == false) == null)
            {
                Order order = new Order();
                order.OrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_db);
                AppUser user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                order.AppUser = user;

                _db.Add(order);
                _db.SaveChanges();
            }
            if (User.IsInRole("Customer"))
            {



                ViewBag.Name = _db.AppUsers.FirstOrDefault(o => o.UserName == User.Identity.Name).FirstName;


                return View(_db.Coupons.Where(o => o.Enabled).ToList());
            }

            if (User.IsInRole("Employee") || User.IsInRole("Manager"))
            {

                ViewBag.Name = _db.AppUsers.FirstOrDefault(o => o.UserName == User.Identity.Name).FirstName;

            }
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Coupons()
        {
            return View();
        }

        public IActionResult Procurements()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

    }
}
