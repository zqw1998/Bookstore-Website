using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public enum CardType { Visa, AmericanExpress, Discover, MasterCard }
namespace Team12FinalProject.Controllers
{
    [Authorize]
    public class CreditCardsController : Controller
    {
        private readonly AppDbContext _context;

        public CreditCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CreditCards
        public async Task<IActionResult> Index()
        {

            return View(await _context.CreditCards.Where(c => c.AppUser.UserName == User.Identity.Name).ToListAsync());
        }

        // GET: CreditCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCards
                .FirstOrDefaultAsync(m => m.CreditCardID == id);
            if (creditCard.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to view this creditcard." });
            }
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // GET: CreditCards/Create
        public IActionResult Create()
        {
            List<CreditCard> ccs = _context.CreditCards.Where(c => c.AppUser.UserName == User.Identity.Name).ToList();
            Int32 num = ccs.Count();
            if (num < 3)
            {
                return View();
            }
            return View("Error", new String[] { "You already have three credit cards." });
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditCardID,CardHolder,CreditCardNumber,CardType")] CreditCard creditCard)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            creditCard.AppUser = user;

            if (ModelState.IsValid)
            {
                try
                {
                    Int64 intNumber = Convert.ToInt64(creditCard.CreditCardNumber);
                }
                catch
                {
                    ViewBag.Message = "Please enter a valid credit card number";
                    return View("Create");
                }
                _context.Add(creditCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCards.FindAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }
            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditCardID,CardHolder,CreditCardNumber,CardType")] CreditCard creditCard)
        {
            if (id != creditCard.CreditCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        Int32 intNumber = Convert.ToInt32(creditCard.CreditCardNumber);
                    }
                    catch
                    {
                        ViewBag.Message = "Please enter a valid credit card number";
                        return View("Edit");
                    }
                    _context.Update(creditCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardExists(creditCard.CreditCardID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCards
                .FirstOrDefaultAsync(m => m.CreditCardID == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCard = await _context.CreditCards.FindAsync(id);
            _context.CreditCards.Remove(creditCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCards.Any(e => e.CreditCardID == id);
        }
        /*
        public SelectList GetAllTypes()
        {
            List<CardType> cardTypes = _db.cardTypes.ToList();
            SelectList AllTypes = new SelectList(cardTypes.OrderBy(t=>t.CreditCardID), "CreditCardID", "CardType");
            return AllTypes;
        }
        */
    }
}