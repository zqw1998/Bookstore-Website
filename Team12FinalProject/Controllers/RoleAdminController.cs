//Change this using statement to match your project
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

//Update these using statements to match your project
using Team12FinalProject.DAL;
using Team12FinalProject.Models;

//Change this namespace to match your project
namespace Team12FinalProject.Controllers
{
    //TODO: Uncomment this line once you have roles working correctly
    [Authorize]
    public class RoleAdminController : Controller
    {
        private AppDbContext _db;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public RoleAdminController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // GET: /RoleAdmin/
        public async Task<ActionResult> Index()
        {
            List<RoleEditModel> roles = new List<RoleEditModel>();

            foreach (IdentityRole role in _roleManager.Roles)
            {
                List<AppUser> members = new List<AppUser>();
                List<AppUser> nonMembers = new List<AppUser>();
                foreach (AppUser user in _userManager.Users)
                {
                    var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                    list.Add(user);
                }
                RoleEditModel re = new RoleEditModel();
                re.Role = role;
                re.Members = members;
                re.NonMembers = nonMembers;
                roles.Add(re);
            }
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            //if code gets this far, we need to show an error
            return View(name);
        }

        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();
            foreach (AppUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEditModel { Role = role, Members = members, NonMembers = nonMembers });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            IdentityResult result2;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    AppUser user = await _userManager.FindByIdAsync(userId);
                    result = await _userManager.AddToRoleAsync(user, "Manager");
                    result2 = await _userManager.RemoveFromRoleAsync(user, "Employee");
                    if (!result.Succeeded && !result2.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }

                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    AppUser user = await _userManager.FindByIdAsync(userId);
                    result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role Not Found" });
        }

        [Authorize]
        public ActionResult ModifyE(string id)
        {
            AppUser user = _db.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ModifyE(string id, /*[Bind("FirstName,LastName,PhoneNumber,Street,City,State,ZipCode")]*/ AppUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = _db.Users.FirstOrDefault(c => c.Id == user.Id);
                    appUser.FirstName = user.FirstName;
                    appUser.LastName = user.LastName;
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
            return View("ModifyE");

            //AppUser user2 = _db.Users.FirstOrDefault(u => u.Id == id);
            //user2.FirstName = user.FirstName;
            //user2.LastName = user.LastName;
            //user2.PhoneNumber = user.PhoneNumber;
            //user2.Street = user.Street;
            //user2.City = user.City;
            //user2.State = user.State;
            //user2.ZipCode = user.ZipCode;

            //    _db.Update(user2);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index", "RoleAdmin");
        }

        [Authorize]
        public ActionResult ModifyC(string id)
        {
            AppUser user = _db.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ModifyC(string id, [Bind("Email,FirstName,LastName,PhoneNumber,Street,City,State,ZipCode")] AppUser user)
        {
            //_db.Users.Update(user);
            //_db.SaveChanges();
            //return RedirectToAction("Index", "RoleAdmin");
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                AppUser user2 = _db.Users.FirstOrDefault(u => u.Id == id);
                user2.FirstName = user.FirstName;
                user2.LastName = user.LastName;
                user2.Email = user.Email;
                user2.PhoneNumber = user.PhoneNumber;
                user2.Street = user.Street;
                user2.City = user.City;
                user2.State = user.State;
                user2.ZipCode = user.ZipCode;
                user2.UserName = user.Email;
                user2.NormalizedEmail = user.Email;
                user2.NormalizedUserName = user.Email;
                _db.Update(user2);
                _db.SaveChanges();
                return RedirectToAction("Index", "RoleAdmin");
            }
            return View();
        }

        public ActionResult RegisterE()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        // This is the method where you create a new user
        public async Task<ActionResult> RegisterE(RegisterViewModel model)
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
                    CustomerNumber = model.CustomerNumber,
                    Birthday = model.Birthday,
                    Initial = model.Initial,  //
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    SSN = model.SSN, //

                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Add user to desired role
                    //This will not work until you have seeded Identity OR added the "Customer" role 
                    //by navigating to the RoleAdmin controller and manually added the "Customer" role

                    await _userManager.AddToRoleAsync(user, "Employee");
                    //another example
                    //await _userManager.AddToRoleAsync(user, "Manager");

                    return RedirectToAction("Index", "RoleAdmin");
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

        public ActionResult RegisterC()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        // This is the method where you create a new user
        public async Task<ActionResult> RegisterC(RegisterViewModel model)
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
                    CustomerNumber = model.CustomerNumber,
                    Birthday = model.Birthday,
                    Initial = model.Initial,  //
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    SSN = model.SSN, //

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

                    return RedirectToAction("Index", "RoleAdmin");
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

        public async Task<IActionResult> Fire(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fire(AppUser user, string id)
        {
            AppUser appUser = _db.Users.Find(user.Id);

            //Update the notes
            appUser.Disabled = user.Disabled;

            //Update the database
            _db.Users.Update(appUser);

            //Save changes
            _db.SaveChanges();

            //Go back to index
            return RedirectToAction(nameof(Index));
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }



    }
}



