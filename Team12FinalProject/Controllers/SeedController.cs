﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team12FinalProject.Seeding;
using Team12FinalProject.Models;
using Team12FinalProject.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public class SeedController : Controller
    {
        private AppDbContext _db;

        public SeedController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeedBooks()
        {
            try
            {
                Seeding.SeedBooks.SeedAllBooks(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The data has already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
            }

            return View("Confirm");
        }


        public IActionResult SeedGenres()
        {
            try
            {
                Seeding.SeedGenres.SeedAllGenres(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The data has already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
            }

            return View("Confirm");
        }
    }
}
