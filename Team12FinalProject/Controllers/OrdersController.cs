﻿ using System; using System.Collections.Generic; using System.Linq; using System.Threading.Tasks; using Microsoft.AspNetCore.Mvc; using Team12FinalProject.DAL; using Team12FinalProject.Models; using Team12FinalProject.Utilities; using Microsoft.EntityFrameworkCore; using Microsoft.AspNetCore.Mvc.Rendering; using Microsoft.AspNetCore.Identity; using Microsoft.Extensions.DependencyInjection; using Microsoft.AspNetCore.Authorization; using System.Net.Mail; using System.Net;  // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860  namespace Team12FinalProject.Controllers {     public enum Confirm { Yes, No }     [Authorize(Roles = "Manager, Customer")]     public class OrdersController : Controller     {          private readonly AppDbContext _context;          public OrdersController(AppDbContext context)         {             _context = context;         }          // GET: /<controller>         public IActionResult Index()         {             List<Order> Orders = new List<Order>();             if (User.IsInRole("Customer") )             {                 Orders = _context.Orders.OrderByDescending(o => o.OrderID).Include(o => o.OrderDetails).Where(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == true).ToList();             }             if (User.IsInRole("Manager")) //user is manager and can see all orders             {                 Orders = _context.Orders.OrderByDescending(o=>o.OrderID).Include(o => o.OrderDetails).Where(o=> o.CheckOutStatus==true).ToList();             }             return View(Orders);         }          // GET: Orders/Details/5         public ActionResult Details(int? id, String CouponC)         {              if (id == null)             {                 return View("Error", new string[] { "Specify an order to view!" });             }             Order order = _context.Orders                                   .Include(o => o.AppUser)                                   .Include(o => o.OrderDetails).ThenInclude(o => o.Book)                                   .FirstOrDefault(o => o.OrderID == id);             Shipping ship = _context.Shippings.FirstOrDefault(s => s.ShippingID == 1);             List<OrderDetail> oos = new List<OrderDetail>();             List<OrderDetail> dc = new List<OrderDetail>();             foreach (OrderDetail o in order.OrderDetails)             {                 if(o.Book.CopiesOnHand < o.Quantity && order.CheckOutStatus==false)                 {                     OrderDetail od = _context.OrderDetails.FirstOrDefault(a => a.OrderDetailID == o.OrderDetailID);                     oos.Add(od);                     /*_context.OrderDetails.Remove(od);                     _context.SaveChanges();*/                  }                 if(o.Book.Discontinued == true && order.CheckOutStatus == false)                 {                     OrderDetail od = _context.OrderDetails.FirstOrDefault(a => a.OrderDetailID == o.OrderDetailID);                     dc.Add(od);                      /*return View("Error", new string[] { "The book "+o.Book.Title+" has been discontinued" });*/                 }             }             if (oos.Count != 0)             {                 foreach(OrderDetail d in oos)                 {                     OrderDetail od = _context.OrderDetails.FirstOrDefault(a => a.OrderDetailID == d.OrderDetailID);                     _context.OrderDetails.Remove(od);                     _context.SaveChanges();                 }                  string s = "We are sorry to tell you that your book in shopping cart has been out of stock!";                 SendEmail(order.AppUser.Email, "Out of Stock Book Notification", s);                 return View("Error", new string[] { "The book(s) is(are) out of stock" });             }              if (dc.Count != 0)             {                 foreach (OrderDetail d in dc)                 {                     OrderDetail od = _context.OrderDetails.FirstOrDefault(a => a.OrderDetailID == d.OrderDetailID);                     _context.OrderDetails.Remove(od);                     _context.SaveChanges();                 }                  string s = "We are sorry to tell you that your book has been discontinued!";                 SendEmail(order.AppUser.Email, "Discountinued Book Notification", s);                 return View("Error", new string[] { "The book(s) has(have) been discontinued" });             }               if (order.OrderDetails.Sum(rd => rd.Quantity) == 0)             {                 order.ShippingAmt = 0;                 _context.SaveChanges();             }             else             {                 order.ShippingAmt = ship.ShippingBase + ship.ShippingAddition * (order.OrderDetails.Sum(rd => rd.Quantity) - 1);                 _context.SaveChanges();             }             if (CouponC != null)             {                 Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == CouponC);                 order.Coupon = coupon;                 _context.SaveChanges();                                  if (coupon.Enabled == false)                 {                     return View("Error", new string[] { "This coupon code has expired!" });                  }                 if (coupon.CouponType == 0)                 {                     if (order.Subtotal < coupon.Amount)                     {                         return View("Error", new string[] { "You have not reach the free shipping amount!" });                     }                     else                     {                         order.ShippingAmt = 0;                         order.DiscountAmt = 0;                         _context.SaveChanges();                     }                 }                 else                 {                     order.DiscountAmt = coupon.Amount * order.Subtotal * 0.01m;                     order.ShippingAmt = ship.ShippingBase + ship.ShippingAddition * (order.OrderDetails.Sum(rd => rd.Quantity) - 1);                     _context.SaveChanges();                 }             }             else             {                 order.DiscountAmt = 0;                 _context.SaveChanges();                                  }              //make sure a customer isn't trying to look at someone else's order             if (User.IsInRole("Manager") == false && order.AppUser.UserName != User.Identity.Name)             {                 return View("Error", new string[] { "You are not authorized to view this order!" });             }              if (order == null)             {                 return View("Error", new string[] { "Order was not found" });             }             return View(order);         }           // GET: Orders/Create         [Authorize]         public ActionResult Create()         {             return View();         }          // POST: Orders/Create         // To protect from overposting attacks, please enable the specific properties you want to bind to, for          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.         [HttpPost]         [ValidateAntiForgeryToken]         public ActionResult Create([Bind("OrderID,OrderNumber,OrderDate, CheckOutStatus")] Order order)         {             order.OrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);             order.CheckOutStatus = false;             //order.OrderDate = DateTime.Today;             order.AppUser = _context.Users.Find(User.Identity.Name);             _context.SaveChanges();              if (ModelState.IsValid)             {                 _context.Orders.Add(order);                 _context.SaveChanges();                  // direct them to a view that will allow them to add a product to the order                  return RedirectToAction("Index", "Books", new { id = order.OrderID });             }              return View(order);          }          [Authorize]         public ActionResult AddToOrder(int id)         {             List<OrderDetail> AllOrderDetails = new List<OrderDetail>();             var query2 = from e in _context.OrderDetails                          select e;             query2 = query2.Include(o => o.Book).Include(o => o.Order).Where(o => o.Order.AppUser.UserName == User.Identity.Name && o.Order.CheckOutStatus == false).Where(o => o.Book.BookID == id);             AllOrderDetails = query2.ToList();             if (AllOrderDetails.Any())             {                 return View("Error", new string[] { "You already have this book in your cart!" });             }             Order order = _context.Orders.FirstOrDefault(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == false);             Book b = _context.Books.FirstOrDefault(o => o.BookID == id);             OrderDetail od = new OrderDetail() { Order = order, Book = b };             return View("AddToOrder", od);         }          [HttpPost]         public ActionResult AddToOrder(OrderDetail od)         {             Book bo = _context.Books.FirstOrDefault(b => b.BookID == od.Book.BookID);             //Shipping sh = _context.Shippings.FirstOrDefault(s => s.ShippingID == 1);             if (bo.CopiesOnHand < od.Quantity)             {                 return View("Error", new string[] { "The books in stock is less than the amount you entered." });             }             Order order = _context.Orders.Include(r => r.OrderDetails).ThenInclude(r => r.Book)                                   .FirstOrDefault(r => r.OrderID == od.Order.OrderID);              od.Order = order;             od.Book = bo;             od.BookPrice = bo.Price;               if (ModelState.IsValid)//model meets all requirements             {                 _context.OrderDetails.Add(od);                 _context.SaveChanges();                 return RedirectToAction("Details", "Orders", new { id = od.Order.OrderID });             }              return View(od);          }          // GET: Orders/Edit/5         public IActionResult Edit(int? id)         {             if (id == null)             {                 return NotFound();             }              var order = _context.Orders                                         .Include(r => r.OrderDetails)                                 .ThenInclude(r => r.Book)                                         .FirstOrDefault(r => r.OrderID == id);             if (order == null)             {                 return NotFound();             }             return View(order);         }          // POST: Orders/Edit/5         // To protect from overposting attacks, please enable the specific properties you want to bind to, for          // more details see http://go.microsoft.com/fwlink/?LinkId=317598.         [HttpPost]         [ValidateAntiForgeryToken]         public IActionResult Edit(Order order)         {             //Find the related registration in the database             Order DbOrd = _context.Orders.Find(order.OrderID);              //Update the notes             DbOrd.Note = order.Note;              //Update the database             _context.Orders.Update(DbOrd);              //Save changes             _context.SaveChanges();              //Go back to index             return RedirectToAction(nameof(Index));         }          public IActionResult RemoveFromOrder(int? id)         {             if (id == null)             {                 return View("Error", new string[] { "You need to specify an order id" });             }              Order ord = _context.Orders.Include(r => r.OrderDetails).ThenInclude(r => r.Book).FirstOrDefault(r => r.OrderID == id);              if (ord == null || ord.OrderDetails.Count == 0)//registration is not found             {                 return RedirectToAction("Details", new { id = id });             }              //pass the list of order details to the view             return View(ord.OrderDetails);         }          [Authorize]         public ActionResult CheckOut(int? id, string CouponC)         {             if (id == null)             {                 return View("Error", new string[] { "You need to specify an order id" });             }              Order order = _context.Orders                                   .Include(o => o.AppUser)                                   .Include(o => o.OrderDetails).ThenInclude(o => o.Book)                 .FirstOrDefault(o => o.OrderID == id);             if (order.OrderDetails.Sum(rd => rd.Quantity) == 0)             {                 return View("Error", new string[] { "Your shopping cart is empty!" });             }             /*if (CouponC != null)             {                 Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == CouponC);                 order.Coupon = coupon;                 if (coupon.Enabled == false)                 {                     return View("Error", new string[] { "This coupon code has expired!" });                  }                 if (coupon.CouponType == 0)                 {                     if (order.Subtotal < coupon.Amount)                     {                         return View("Error", new string[] { "You have not reach the free shipping amount!" });                     }                     else                     {                         order.ShippingAmt = 0;                     }                 }                 else                 {                     order.DiscountAmt = coupon.Amount * order.Subtotal * 0.01m;                 }             }*/             if (order == null)             {                 return View("Error", new string[] { "You need to specify an order id" });             }             else             {                 if (User.IsInRole("Manager") || order.AppUser.UserName == User.Identity.Name)                 {                     ViewBag.allCards = GetAllCards(order);                     return View(order);                 }                 else                 {                     return View("Error", new string[] { "This is not your order!!" });                 }             }          }          [HttpPost]         public ActionResult CheckOut([Bind("OrderID,CreditCardNumber,CardType,CheckOutStatus")] Order order, int SelectedCard, Confirm Confirm, string CouponC)         {             if (ModelState.IsValid)             {                 Order orderToChange = _context.Orders.Include(o => o.OrderDetails).ThenInclude(o => o.Book)                                               .FirstOrDefault(o => o.OrderID == order.OrderID);                  CreditCard cd = _context.CreditCards.Find(SelectedCard);                 Shipping ship = _context.Shippings.FirstOrDefault(s => s.ShippingID == 1);                 //SearchCoupons(CouponC);                 //orderToChange.ShippingAmt = ship.ShippingBase + ship.ShippingAddition * (orderToChange.OrderDetails.Sum(rd => rd.Quantity) - 1);                 /*if (CouponC != null)                 {                     Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == CouponC);                     orderToChange.Coupon = coupon;                     if (coupon.Enabled == false)                     {                         return View("Error", new string[] { "This coupon code has expired!" });                      }                     if (coupon.CouponType == 0)                     {                         if (orderToChange.Subtotal < coupon.Amount)                         {                             return View("Error", new string[] { "You have not reach the free shipping amount!" });                         }                         else                         {                             orderToChange.ShippingAmt = 0;                         }                     }                     else                     {                         orderToChange.DiscountAmt = coupon.Amount * order.Subtotal * 0.01m;                     }                 }*/                 if (Confirm == Confirm.Yes)                 {                                          orderToChange.CreditCard = cd;                     if (cd == null)                     {                         return RedirectToAction("Index", "CreditCards");                     }                     orderToChange.CreditCard.CardType = cd.CardType;                     orderToChange.CheckOutStatus = true;                     orderToChange.OrderDate = DateTime.Today;                     _context.Entry(orderToChange).State = EntityState.Modified;                     _context.SaveChanges();                     _context.Update(orderToChange);                      foreach (OrderDetail od in orderToChange.OrderDetails)                     {                         Book b = _context.Books.Include(o => o.OrderDetails).FirstOrDefault(o => o.BookID == od.Book.BookID);                         b.CopiesOnHand = b.CopiesOnHand - od.Quantity;                          _context.Books.Update(b);                         _context.SaveChanges();                      }                      return RedirectToAction("Summary", new { id = order.OrderID });                 }                 else                 {                     orderToChange.CheckOutStatus = false;                     _context.Entry(orderToChange).State = EntityState.Modified;                     _context.SaveChanges();                     return RedirectToAction("Index");                 }             }              return View(order);         }            public ActionResult Summary(int? id, String CouponC)         {             if (id == null)             {                 return View("Error", new string[] { "You need to specify an order id" });             }             Order order = _context.Orders                                   .Include(o => o.AppUser)                                   .Include(o => o.CreditCard)                                   .Include(o => o.OrderDetails).ThenInclude(o => o.Book)                 .FirstOrDefault(o => o.OrderID == id && o.AppUser.UserName == User.Identity.Name);             /*             if (CouponC != null)             {                 Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == CouponC);                 order.Coupon = coupon;                 if (coupon.Enabled == false)                 {                     return View("Error", new string[] { "This coupon code has expired!" });                  }                 if (coupon.CouponType == 0)                 {                     if (order.Subtotal < coupon.Amount)                     {                         return View("Error", new string[] { "You have not reach the free shipping amount!" });                     }                     else                     {                         order.ShippingAmt = 0;                     }                 }                 else                 {                     order.DiscountAmt = coupon.Amount * order.Subtotal * 0.01m;                 }             }             if (order == null)             {                 return View("Error", new string[] { "Order was not found" });             }*/              String s = "Order Confirmation" + "\n" + "Confirmation Number:" + order.OrderNumber + "\n\n";             List<OrderDetail> ods = order.OrderDetails;             foreach (OrderDetail od in ods)             {                 s = s + "Book Title:" + od.Book.Title + "\n"                     + "Book Price:" + od.BookPrice.ToString("C") + "\n"                                           + "Book Quantity:" + od.Quantity.ToString() + "\n\n";             }              s = s + "Subtotal:" + order.Subtotal.ToString("C") + "\n"                  + "Total Price" + order.TotalPrice.ToString("C") + "\n";                SendEmail(order.AppUser.Email, "Order Confirmation", s);             ViewBag.rec = GetBookReccomendations(ods[0].OrderDetailID);             if (User.IsInRole("Customer") && _context.Orders.FirstOrDefault(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == false) == null)             {                 Order order1 = new Order();                 order1.OrderNumber = GenerateNextOrderNumber.GetNextOrderNumber(_context);                 AppUser user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);                 order1.AppUser = user;                  _context.Add(order1);                 _context.SaveChanges();             }             if (User.IsInRole("Manager") || order.AppUser.UserName == User.Identity.Name)             {                  return View(order);             }             else             {                 return View("Error", new string[] { "This is not your order!!" });             };          }          public ActionResult GetEmail(int? id)         {             if (id == null)             {                 return View("Error", new string[] { "You need to specify an order id" });             }             Order order = _context.Orders                                   .Include(o => o.AppUser)                                   .Include(o => o.CreditCard)                                   .Include(o => o.OrderDetails).ThenInclude(o => o.Book).FirstOrDefault(o => o.OrderID == id);             if (order == null)             {                 return View("Error", new string[] { "Order was not found" });             }             return View(order);         }          public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)         {              //Create an email client to send the emails             var client = new SmtpClient("smtp.gmail.com", 587)             {                 Credentials = new NetworkCredential("xuanj826@gmail.com", "Jn630429"),                 EnableSsl = true             };             //Add anything that you need to the body of the message             // /n is a new line – this will add some white space after the main body of the message             String finalMessage = emailBody + "\n\n Thank You!" + "\n Team 12";             //Create an email address object for the sender address             MailAddress senderEmail = new MailAddress("xuanj826@gmail.com", "Team 12");              MailMessage mm = new MailMessage();             mm.Subject = "Team 12 - " + emailSubject;             mm.Sender = senderEmail;             mm.From = senderEmail;             mm.To.Add(new MailAddress(toEmailAddress));             mm.Body = finalMessage;             client.Send(mm);          }          public SelectList GetAllCards(Order order)         {             String UserID = User.Identity.Name;             List<CreditCard> allCards = _context.CreditCards.Where(c => c.AppUser.UserName == UserID).ToList();              //convert the list to a select list             SelectList selCredits = new SelectList(allCards, "CreditCardID", "CardNumberShort");              //return the select list             return selCredits;         }            public IActionResult ShoppingCart()         {             Order order = _context.Orders.OrderByDescending(o => o.OrderID).FirstOrDefault(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == false);             return RedirectToAction("Details", "Orders", new { id = order.OrderID });         }          public ActionResult SearchCoupons(string CouponC)         {              List<Coupon> Coupons = _context.Coupons.ToList();             List<Order> Orders = _context.Orders.ToList();             string co = CouponC;               Order order = _context.Orders.OrderByDescending(o => o.OrderID).FirstOrDefault(o => o.AppUser.UserName == User.Identity.Name && o.CheckOutStatus == false);             var query = from c in _context.Coupons                         select c;              if (CouponC == null || CouponC == "")             {                 return View("Error", new string[] { "You did not enter any coupon code!" });             }              else             {                 Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == CouponC);                 if (coupon == null)                 {                     return View("Error", new string[] { "You enter a invalid coupon code." });                 }                 else                 {                     List<int> coup = new List<int>();                     AppUser user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);                     foreach (Order o in user.Orders)                     {                         if (o.CheckOutStatus == true)                         {                             if (o.Coupon != null)                             {                                 coup.Add(o.Coupon.CouponID);                             }                         }                      }                     if (coup.Contains(coupon.CouponID))                     {                         return View("Error", new string[] { "You have already used this coupon in the previous order." });                     }                     return RedirectToAction("Details", "Orders", new { id = order.OrderID, CouponC = CouponC });                 }             }          }          public List<Book> GetBookReccomendations(int id)         {             List<Order> Allorder = _context.Orders.Where(c => c.AppUser.UserName == User.Identity.Name && c.CheckOutStatus == true).Include(o => o.OrderDetails).ThenInclude(o => o.Book).ThenInclude(o => o.Genre).Include(o => o.OrderDetails).ThenInclude(o => o.Book).ThenInclude(o => o.Reviews).ToList();               List<Book> BooksToReccommend = new List<Book>();             List<Book> BooksBought = new List<Book>();             List<String> author = new List<String>();                //find list of books already bought             foreach (Order order in Allorder)             {                 foreach (OrderDetail o in order.OrderDetails)                 {                     BooksBought.Add(o.Book);                 }             }               OrderDetail od = _context.OrderDetails.Include(c => c.Book).ThenInclude(c => c.Genre).Include(c => c.Book).ThenInclude(c => c.Reviews).FirstOrDefault(c => c.OrderDetailID == id);             var Authorquery = from b in _context.Books                               select b;             Authorquery = Authorquery.Include(c => c.Genre).Include(c => c.Reviews).Where(c => c.Author == od.Book.Author).Where(c => c.Genre == od.Book.Genre);             //same author and genre             List<Book> AllSimilar = new List<Book>();              AllSimilar = Authorquery.ToList();             //new list to exclude those bought             List<Book> SimilarNotBought = AllSimilar.Except(BooksBought).Except(BooksToReccommend).ToList();             if (SimilarNotBought.Count > 0)             {                 //sort by rating                 List<Book> SortedBook = new List<Book>();                 var sortquery = from b in SimilarNotBought                                 select b;                 SortedBook = sortquery.OrderByDescending(c => c.AvgRating).ToList();                 ;                 BooksToReccommend.Add(SortedBook[0]);                 author.Add(SortedBook[0].Author);              }             var HighRatequery = from d in _context.Books                                 select d;              HighRatequery = HighRatequery.Include(c => c.Genre).Include(c => c.Reviews).Where(c => c.Genre == od.Book.Genre);             List<Book> HighRateBook = new List<Book>();             HighRateBook = HighRatequery.ToList();             List<Book> ExcludeHRBook = HighRateBook.Except(BooksBought).ToList();             ExcludeHRBook = ExcludeHRBook.Except(BooksToReccommend).ToList();              List<Book> SortedHighRateBook = new List<Book>();             var sortquery2 = from b in ExcludeHRBook                              select b;             SortedHighRateBook = sortquery2.OrderByDescending(c => c.AvgRating).ToList();                 //add high rate books with customer rating greater than 4 and different authors             foreach (Book b in SortedHighRateBook)             {                 Boolean Reccommend = true;                 foreach (Review r in b.Reviews)                 {                      if (r.CustomerRating < 4)                     {                         Reccommend = false;                     }                  }                  foreach (String a in author)                 {                     if (b.Author == a)                     {                         Reccommend = false;                     }                 }                  if (Reccommend == false)                 {                     continue;                 }                 else                 {                     BooksToReccommend.Add(b);                     SortedHighRateBook = SortedHighRateBook.Except(BooksToReccommend).ToList();                      if (BooksToReccommend.Count == 3)                     {                         return BooksToReccommend;                     }                 }               }              //add books with low rating from the same genre             foreach (Book b in SortedHighRateBook)             {                 SortedHighRateBook = SortedHighRateBook.Except(BooksToReccommend).ToList();                 BooksToReccommend.Add(b);                 if (BooksToReccommend.Count == 3)                 {                     return BooksToReccommend;                 }              }             List<Book> AllBook = new List<Book>();             var Allquery = from v in _context.Books                            select v;             Allquery = Allquery.Include(c => c.Genre).Include(c => c.Reviews);             AllBook = Allquery.ToList();             List<Book> ExcludeAllBook = AllBook.Except(BooksBought).Except(BooksToReccommend).ToList();             List<Book> SortedAllBook = new List<Book>();             var sortquery3 = from b in ExcludeAllBook                              select b;             SortedAllBook = sortquery3.OrderByDescending(c => c.AvgRating).ToList();               //add highest overall books                foreach (Book b in SortedAllBook)             {                  BooksToReccommend.Add(b);                 SortedAllBook = SortedAllBook.Except(BooksToReccommend).ToList();                 if (BooksToReccommend.Count == 3)                 {                     return BooksToReccommend;                 }              }             return BooksToReccommend;          }       } }  