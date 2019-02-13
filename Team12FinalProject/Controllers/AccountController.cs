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
using System.Net.Mail;
using System.Net;

namespace Team12FinalProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _db;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signIn;

            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
            //_userManager.UserValidators = new UserValidator<AppUser>()
            //{

            //}
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            AppUser user = _db.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                if (user.Disabled == true)
                {
                    return View("Error", new string[] { "Your account has been disabled." });
                }
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        // This is the method where you create a new user
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (_db.Users.FirstOrDefault(x => x.Email == model.Email) == null)
            {
                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,

                        //TODO: You will need to add all of the properties for your User model here
                        //Make sure that you have included ALL of the properties and that they match
                        //the model class EXACTLY!!
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CustomerNumber = model.CustomerNumber, ///
                        Birthday = model.Birthday,
                        Initial = model.Initial,  //
                        Street = model.Street,
                        City = model.City,
                        State = model.State,
                        ZipCode = model.ZipCode,

                    };

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        // Add user to desired role
                        //This will not work until you have seeded Identity OR added the "Customer" role 
                        //by navigating to the RoleAdmin controller and manually added the "Customer" role

                        await _userManager.AddToRoleAsync(user, "Customer");
                        //another example
                        //await _userManager.AddToRoleAsync(user, "Manager");
                        String s = "Welcome to Team 12 Online Book Store. We appreciate you as our new customer!";
                        SendEmail(user.Email, "Registration Confirmation", s);
                        Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            else
            {
                return View("Error", new string[] { "This Email Account has already existed." });
            }

        }

        //GET: Account/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            //String id = User.Identity.Name;
            //AppUser user = _db.Users.FirstOrDefault(u => u.UserName == id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AppUser user = _db.Users.Find(userId);

            //populate the view model
            ivm.Email = user.Email;

            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.CustomerNumber = user.CustomerNumber; //
            ivm.Birthday = user.Birthday;
            ivm.Initial = user.Initial;  //
            ivm.Street = user.Street;
            ivm.City = user.City;
            ivm.State = user.State;
            ivm.ZipCode = user.ZipCode;

            return View(ivm);
        }



        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);
                String s = "As a friendly reminder, your password has been changed.";
                SendEmail(userLoggedIn.Email, "Change Password Notification", s);
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

        //GET:/Account/AccessDenied
        public ActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AppUser user = _db.Users.Find(userId);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(string id, [Bind("Email,FirstName,LastName,PhoneNumber,Street,City,State,ZipCode")] AppUser user)
        {
            if (ModelState.IsValid)
            {
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                AppUser user2 = _db.Users.Find(id);
                user2.FirstName = user.FirstName;
                user2.LastName = user.LastName;
                user2.Email = user.Email;
                user2.PhoneNumber = user.PhoneNumber;
                user2.Street = user.Street;
                user2.City = user.City;
                user2.State = user.State;
                user2.ZipCode = user.ZipCode;


                //_db.Entry(user2).State = EntityState.Modified;
                _db.Update(user2);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public ActionResult EditE()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AppUser user = _db.Users.Find(userId);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditE(string id, /*[Bind("PhoneNumber,Street,City,State,ZipCode")]*/ AppUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = _db.Users.FirstOrDefault(c => c.Id == user.Id);

                    appUser.Street = user.Street;
                    appUser.City = user.City;
                    appUser.State = user.State;
                    appUser.ZipCode = user.ZipCode;
                    appUser.PhoneNumber = user.PhoneNumber;
                    _db.Update(appUser);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View("EditE");

            //if (ModelState.IsValid)
            //{
            //    //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //    AppUser user2 = _db.Users.Find(id);
            //    user2.PhoneNumber = user.PhoneNumber;
            //    user2.Street = user.Street;
            //    user2.City = user.City;
            //    user2.State = user.State;
            //    user2.ZipCode = user.ZipCode;
            //    //user2.UserName = user.Email;
            //    //_db.Entry(user2).State = EntityState.Modified;
            //    _db.Update(user2);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View("EditE");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {

            //Create an email client to send the emails
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("xuanj826@gmail.com", "Jn630429"),
                EnableSsl = true
            };
            //Add anything that you need to the body of the message
            // /n is a new line – this will add some white space after the main body of the message
            String finalMessage = emailBody + "\n\n Thank You!" + "\n Team 12";
            //Create an email address object for the sender address
            MailAddress senderEmail = new MailAddress("xuanj826@gmail.com", "Team 12");

            MailMessage mm = new MailMessage();
            mm.Subject = "Team 12 - " + emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add(new MailAddress(toEmailAddress));
            mm.Body = finalMessage;
            client.Send(mm);

        }
    }
}




