using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using Team12FinalProject.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team12FinalProject.Controllers
{
    public enum Condition { InStockOnly, All }
    public class BooksController : Controller
    {
        private readonly AppDbContext _db;

        public BooksController(AppDbContext context)
        {
            _db = context;
        }
        public ActionResult ShowAll(int SelectedFilter, Condition SelectedCondition)
        {
            List<Book> AllBooks = new List<Book>();
            AllBooks = _db.Books.Include(r => r.Reviews).ToList();
            SelectedCondition = Condition.All;
            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = _db.Books.Count();
            ViewBag.AllFilters = GetAllFilters();
            if (SelectedFilter == 0)
            {
                return View("Index", AllBooks.OrderBy(b => b.Title));
            }
            else if (SelectedFilter == 1)
            {
                return View("Index", AllBooks.OrderBy(b => b.Author));
            }
            else if (SelectedFilter == 2)
            {
                return View("Index", AllBooks.OrderByDescending(b => b.OrderDetails.Sum(sum => sum.Quantity)));
            }
            else if (SelectedFilter == 3)
            {
                return View("Index", AllBooks.OrderByDescending(b => b.PublishedDate));
            }
            else if (SelectedFilter == 4)
            {
                return View("Index", AllBooks.OrderBy(b => b.PublishedDate));
            }
            else
            {
                return View("Index", AllBooks.OrderByDescending(b => b.AvgRating));
            };
        }
        public ActionResult Index(String SearchString, int SelectedFilter, Condition SelectedCondition)
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
            List<Book> SelectedBooks = new List<Book>();

            var query = from b in _db.Books
                        select b;

            switch (SelectedCondition)
            {
                case Condition.InStockOnly:
                    query = query.Where(r => r.Availablity == "In stock");
                    break;
                default:

                    break;
            }

            if (SearchString == null || SearchString == "")
            {

                ViewBag.TotalBooks = _db.Books.Count();
                SelectedBooks = query.Include(r => r.Reviews).Include(r => r.Genre).Include(r=>r.OrderDetails).ThenInclude(r=>r.Order).ThenInclude(r=>r.Coupon).ToList();
                ViewBag.SelectedBooks = SelectedBooks.Count();
                ViewBag.AllFilters = GetAllFilters();
                List<Book> AllBooks = new List<Book>();



                AllBooks = query.Include(r => r.OrderDetails).Include(r => r.Genre).Include(r => r.Reviews).ToList();

                switch (SelectedCondition)
                {
                    case Condition.InStockOnly:
                        query = query.Where(r => r.Availablity == "In stock");
                        break;
                    default:

                        break;
                }

                if (SelectedFilter == 0)
                {
                    return View(AllBooks.OrderBy(b => b.Title));
                }
                else if (SelectedFilter == 1)
                {
                    return View(AllBooks.OrderBy(b => b.Author));
                }
                else if (SelectedFilter == 2)
                {

                    return View(AllBooks.OrderByDescending(b => b.OrderDetails.Sum(sum => sum.Quantity)));
                }
                else if (SelectedFilter == 3)
                {
                    return View(AllBooks.OrderByDescending(b => b.PublishedDate));
                }
                else if (SelectedFilter == 4)
                {
                    return View(AllBooks.OrderBy(b => b.PublishedDate));
                }
                else
                {
                    return View(AllBooks.OrderByDescending(b => b.AvgRating));
                }

            }



            query = query.Where(b => b.Title.ToLower().Contains(SearchString.ToLower()) || b.Author.ToLower().Contains(SearchString.ToLower()));
            SelectedBooks = query.Include(r => r.Genre).Include(r => r.Reviews).Include(r=>r.OrderDetails).ThenInclude(r => r.Order).ThenInclude(r => r.Coupon).ToList();

            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();
            ViewBag.AllFilters = GetAllFilters();

            if (SelectedFilter == 0)
            {
                return View(SelectedBooks.OrderBy(b => b.Title));
            }
            else if (SelectedFilter == 1)
            {
                return View(SelectedBooks.OrderBy(b => b.Author));
            }
            else if (SelectedFilter == 2)
            {
                return View(SelectedBooks.OrderByDescending(b => b.OrderDetails.Sum(sum => sum.Quantity)));
            }
            else if (SelectedFilter == 3)
            {
                return View(SelectedBooks.OrderByDescending(b => b.PublishedDate));
            }
            else if (SelectedFilter == 4)
            {
                return View(SelectedBooks.OrderBy(b => b.PublishedDate));
            }
            else
            {
                return View(SelectedBooks.OrderByDescending(b => b.AvgRating));
            }

        }

        public ActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllFilters = GetAllFilters();

            return View();
        }

        public ActionResult DisplaySearchResults(String SearchTitle, String SearchAuthor, int SelectedGenre, String UniqueNum, int SelectedFilter, Condition SelectedCondition)
        {
            var query = from c in _db.Books
                        select c;


            if (SearchTitle != null)
            {
                query = query.Where(c => c.Title.Contains(SearchTitle));
            }

            if (SearchAuthor != null)
            {
                query = query.Where(c => c.Author.Contains(SearchAuthor));
            }

            if (SelectedGenre != 0)
            {
                Genre GenreToDisplay = _db.Genres.Find(SelectedGenre);
                query = query.Where(c => c.Genre.GenreType.Contains(GenreToDisplay.GenreType));
            }

            if (UniqueNum != null && UniqueNum != "")
            {
                Int32 intUniqueNum;
                try
                {
                    intUniqueNum = Convert.ToInt32(UniqueNum);
                }
                catch
                {
                    ViewBag.Message = UniqueNum + "is not valid number. Please try again";
                    ViewBag.AllGenres = GetAllGenres();

                    return View("DetailedSearch");
                }

                query = query.Where(c => c.UniqueID == intUniqueNum);
            }

            List<Book> BooksToDisplay = query.Include(c => c.Genre).Include(o => o.Reviews).Include(o => o.OrderDetails).ThenInclude(r => r.Order).ThenInclude(r => r.Coupon).ToList();

            ViewBag.TotalBooks = _db.Books.Count();
            ViewBag.SelectedBooks = BooksToDisplay.Count();
            ViewBag.AllFilters = GetAllFilters();

            switch (SelectedCondition)
            {
                case Condition.InStockOnly:
                    query = query.Where(r => r.Availablity == "In stock");
                    break;
                default:

                    break;
            }

            if (SelectedFilter == 0)
            {
                return View("Index", BooksToDisplay.OrderBy(b => b.Title));
            }
            else if (SelectedFilter == 1)
            {
                return View("Index", BooksToDisplay.OrderBy(b => b.Author));
            }
            else if (SelectedFilter == 2)
            {
                return View("Index", BooksToDisplay.OrderByDescending(b => b.OrderDetails.Sum(sum => sum.Quantity)));
            }
            else if (SelectedFilter == 3)
            {
                return View("Index", BooksToDisplay.OrderByDescending(b => b.PublishedDate));
            }
            else if (SelectedFilter == 4)
            {
                return View("Index", BooksToDisplay.OrderBy(b => b.PublishedDate));
            }
            else
            {
                return View("Index", BooksToDisplay.OrderByDescending(b => b.AvgRating));
            }




        }


        public IActionResult Details(int? id)
        {
            Book book;
            if (id == null)
            {
                return View("Error", new String[] { "Book ID not specified - which book do you want to view?" });
            }
            try
            {
                book = _db.Books.Include(c => c.Genre).Include(r => r.Reviews)
                                         .FirstOrDefault(c => c.BookID == id);
            }
            catch
            {
                book = _db.Books.Include(c => c.Genre)
                                         .FirstOrDefault(c => c.BookID == id);

            }

            if (book == null)
            {
                return View("Error", new String[] { "Book not found in database" });
            }

            return View(book);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            ViewBag.AllGenres = GetAllGenres();
            return View();
        }




        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int SelectedGenres, [Bind("BookID,UniqueID,Author,Title,CopiesOnHand,Price,PublishedDate,Cost,Description,AvgRating,Avaliability, Reorder, LastOrdered,Genre")] Book book)
        {
            if(book.Author == null || book.Title == null)
            {
                ViewBag.InvalidCreate = "Book title and author can not be null.";
                ViewBag.AllGenres = GetAllGenres();
                return View(book);
            }
            if (ModelState.IsValid)
            {
                //Generate next course number

                book.UniqueID = GenerateNextUniqueID.GetNextUniqueID(_db);
                book.Genre = _db.Genres.Find(SelectedGenres);

                _db.Add(book);
                _db.SaveChanges();


                return RedirectToAction("Index", "Books");
            }

            ViewBag.AllGenres = GetAllGenres();
            return View(book);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _db.Books.Include(c => c.Genre)
                                         .FirstOrDefault(c => c.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.AllGenres = GetAllGenres(book);
            ViewBag.id = id;
            return View(book);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book, int SelectedGenres)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Book dbBook = _db.Books
                                     .Include(c => c.Genre).Include( c =>c.OrderDetails).ThenInclude(c =>c.Order)
                        .FirstOrDefault(c => c.BookID == book.BookID);

                    dbBook.Price = book.Price;
                    dbBook.Author = book.Author;
                    dbBook.Title = book.Title;
                    dbBook.PublishedDate = book.PublishedDate;
                    dbBook.Cost = book.Cost;
                    dbBook.Reorder = book.Reorder;
                    dbBook.Description = book.Description;
                    foreach(OrderDetail od in dbBook.OrderDetails)
                    {
                        
                        if (od.Order.CheckOutStatus == false)
                        {
                            od.BookPrice = book.Price;
                            _db.OrderDetails.Update(od);
                            _db.SaveChanges();
                        }
                    }
                    dbBook.Genre = _db.Genres.Find(SelectedGenres);

                    _db.Update(dbBook);
                    _db.SaveChanges();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            ViewBag.AllGenres = GetAllGenres();
            return RedirectToAction("Details", "Books", new { id = book.BookID });
        }

        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _db.Genres.ToList();


            Genre SelectNone = new Genre() { GenreID = 0, GenreType = "All Genre" };
            Genres.Add(SelectNone);
            SelectList AllGenres = new SelectList(Genres.OrderBy(r => r.GenreID), "GenreID", "GenreType");

            return AllGenres;
        }

        private SelectList GetAllGenres(Book book)
        {
            //create a list of all the departments
            List<Genre> allGenres = _db.Genres.ToList();




            //create the multiselect with the overload for currently selected items
            SelectList genreList = new SelectList(allGenres, "GenreID", "GenreType", book.Genre.GenreID);

            //return the list
            return genreList;
        }

        public SelectList GetAllFilters()
        {
            List<SelectListItem> Filters = new List<SelectListItem>();
            Filters.Add(new SelectListItem() { Text = "Title", Value = "0" });
            Filters.Add(new SelectListItem() { Text = "Author", Value = "1" });
            Filters.Add(new SelectListItem() { Text = "Most Popular", Value = "2" });
            Filters.Add(new SelectListItem() { Text = "Newest", Value = "3" });
            Filters.Add(new SelectListItem() { Text = "Oldest", Value = "4" });
            Filters.Add(new SelectListItem() { Text = "Highest Rated", Value = "5" });

            SelectList AllFilters = new SelectList(Filters, "Value", "Text");
            return AllFilters;
        }

        public IActionResult Discontinue(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book b = _db.Books.FirstOrDefault(c => c.BookID == id);
            if (b == null)
            {
                return NotFound();
            }
            b.Discontinued = true;
            _db.Update(b);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = b.BookID });
        }

        public IActionResult Continue(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book b = _db.Books.FirstOrDefault(c => c.BookID == id);
            if (b == null)
            {
                return NotFound();
            }
            b.Discontinued = false;
            _db.Update(b);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = b.BookID });
        }


        private bool BookExists(int id)
        {
            return _db.Books.Any(e => e.BookID == id);
        }
    }
}