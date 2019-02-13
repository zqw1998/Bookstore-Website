using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public class GenresController : Controller
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.ToListAsync());
        }
        // GET: Products/Create
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }




        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GenreID,GenreType")] Genre genre, int id)
        {
            if (ModelState.IsValid)
            {
                //Generate next course number


                _context.Add(genre);
                _context.SaveChanges();

                //add connections to suppliers
                //first, find the course you just added


                ViewBag.id = id;
                return RedirectToAction("Edit", "Books", new { id = id });
            }


            return View(genre);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _context.Genres.FirstOrDefault(c => c.GenreID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Genre dbGenre = _context.Genres.FirstOrDefault(c => c.GenreID == genre.GenreID);

                    dbGenre.GenreType = genre.GenreType;


                    _context.Update(dbGenre);
                    _context.SaveChanges();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.GenreID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View();


        }
        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.GenreID == id);
        }
    }
}
