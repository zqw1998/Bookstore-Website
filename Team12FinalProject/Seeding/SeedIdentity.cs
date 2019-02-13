using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

// Make these using statements match your project
using Team12FinalProject.DAL;
using Team12FinalProject.Models;

// Change this namespace to match your project
namespace Team12FinalProject.Seeding
{
    //add identity data
    public static class SeedIdentity
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Add the needed roles
            //if role doesn't exist, add it
            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            AppUser manager1 = _db.Users.FirstOrDefault(u => u.Email == "c.baker@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager1 == null)
            {
                manager1 = new AppUser();
                manager1.LastName = "Baker";
                manager1.FirstName = "Christopher";
                manager1.Initial = "E";
                manager1.Street = "1245 Lake Libris Dr.";
                manager1.City = "Cedar Park";
                manager1.State = "TX";
                manager1.ZipCode = 78613;
                manager1.SSN = "401661146";
                manager1.UserName = "c.baker@bevosbooks.com";
                manager1.Email = "c.baker@bevosbooks.com";
                manager1.PhoneNumber = "(339)532-5649";

                var result = await _userManager.CreateAsync(manager1, "dewey4");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager1 = _db.Users.FirstOrDefault(u => u.UserName == "c.baker@bevosbooks.com");
            }



            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager1, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager1, "Manager");
            }

            _db.SaveChanges();

            
            AppUser customer = _db.Users.FirstOrDefault(u => u.Email == "cbaker@example.com");
            if (customer == null)
            {

                customer = new AppUser();
                customer.CustomerNumber = 9010;
                customer.LastName = "Baker";
                customer.FirstName = "Christopher";
                customer.Initial = "L.";
                customer.Birthday = new DateTime(1949, 11, 23);
                customer.Street = "1898 Schurz Alley";
                customer.City = "Austin";
                customer.State = "TX";
                customer.ZipCode = 78705;
                customer.SSN = "477-44-9589";
                customer.UserName = "cbaker@example.com";
                customer.Email = "cbaker@example.com";
                customer.PhoneNumber = "(572) 545-8641";
                var result = await _userManager.CreateAsync(customer, "bookworm");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer, "customer");
            }
            _db.SaveChanges();

            AppUser customer2 = _db.Users.FirstOrDefault(u => u.Email == "banker@longhorn.net");
            if (customer2 == null)
            {

                customer2 = new AppUser();
                customer2.CustomerNumber = 9011;
                customer2.LastName = "Banks";
                customer2.FirstName = "Michelle";
                customer2.Birthday = new DateTime(1962, 11, 27);
                customer2.Street = "97 Elmside Pass";
                customer2.City = "Austin";
                customer2.State = "TX";
                customer2.ZipCode = 78712;
                customer2.SSN = "247-31-0787";
                customer2.UserName = "banker@longhorn.net";
                customer2.Email = "banker@longhorn.net";
                customer2.PhoneNumber = "(986) 704-8435";
                var result = await _userManager.CreateAsync(customer2, "potato");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer2 = _db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
            }
            if (await _userManager.IsInRoleAsync(customer2, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer2, "customer");
            }

            _db.SaveChanges();

            AppUser customer3 = _db.Users.FirstOrDefault(u => u.Email == "franco@example.com");
            if (customer3 == null)
            {

                customer3 = new AppUser();
                customer3.CustomerNumber = 9012;
                customer3.LastName = "Broccolo";
                customer3.Initial = "V";
                customer3.FirstName = "Franco";
                customer3.Birthday = new DateTime(1992, 11, 10);
                customer3.Street = " 88 Crowley Circle";
                customer3.City = "Austin";
                customer3.State = "TX";
                customer3.ZipCode = 78786;
                customer3.SSN = " 486-47-8748";
                customer3.UserName = "franco@example.com";
                customer3.Email = "franco@example.com";
                customer3.PhoneNumber = "486-47-8748";
                var result = await _userManager.CreateAsync(customer3, "painting");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer3 = _db.Users.FirstOrDefault(u => u.UserName == "franco@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer3, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer3, "customer");
            }

            _db.SaveChanges();

            AppUser customer4 = _db.Users.FirstOrDefault(u => u.Email == "wchang@example.com");
            if (customer4 == null)
            {

                customer4 = new AppUser();
                customer4.CustomerNumber = 9013;
                customer4.LastName = " Chang";
                customer4.Initial = "L";
                customer4.FirstName = "Wendy";
                customer4.Birthday = new DateTime(1997, 5, 16);
                customer4.Street = "56560 Sage Junction";
                customer4.City = " Eagle Pass";
                customer4.State = "TX";
                customer4.ZipCode = 78852;
                customer4.SSN = " 182-52-9193";
                customer4.UserName = "wchang@example.com";
                customer4.Email = "wchang@example.com";
                customer4.PhoneNumber = "486-47-8748";
                var result = await _userManager.CreateAsync(customer4, "texas1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer4 = _db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com");
            }
            if (await _userManager.IsInRoleAsync(customer4, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer4, "customer");
            }

            _db.SaveChanges();

            AppUser customer5 = _db.Users.FirstOrDefault(u => u.Email == "limchou@gogle.com");
            if (customer5 == null)
            {

                customer5 = new AppUser();
                customer5.CustomerNumber = 9014;
                customer5.LastName = "Chou";
                customer5.Initial = "";
                customer5.FirstName = "Lim";
                customer5.Birthday = new DateTime(1970, 4, 6);
                customer5.Street = "60 Lunder Point";
                customer5.City = "Austin";
                customer5.State = "TX";
                customer5.ZipCode = 78729;
                customer5.SSN = " 679-75-0653";
                customer5.UserName = "limchou@gogle.com";
                customer5.Email = "limchou@gogle.com";
                customer5.PhoneNumber = "148-890-7687";
                var result = await _userManager.CreateAsync(customer5, "Anchorage");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer5 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer5, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer5, "customer");
            }

            _db.SaveChanges();

            AppUser customer6 = _db.Users.FirstOrDefault(u => u.Email == "shdixon@aoll.com");
            if (customer6 == null)
            {

                customer6 = new AppUser();
                customer6.CustomerNumber = 9015;
                customer6.LastName = "Dixon";
                customer6.Initial = "D";
                customer6.FirstName = "Shan";
                customer6.Birthday = new DateTime(1984, 1, 12);
                customer6.Street = "9448 Pleasure Avenue";
                customer6.City = "Georgetown";
                customer6.State = "TX";
                customer6.ZipCode = 78628;
                customer6.SSN = "593-06-9800";
                customer6.UserName = "shdixon@aoll.com";
                customer6.Email = "shdixon@aoll.com";
                customer6.PhoneNumber = "689-970-1824";
                var result = await _userManager.CreateAsync(customer6, "aggies");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer6 = _db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
            }
            if (await _userManager.IsInRoleAsync(customer6, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer6, "customer");
            }

            _db.SaveChanges();

            AppUser customer7 = _db.Users.FirstOrDefault(u => u.Email == "j.b.evans@aheca.org");
            if (customer7 == null)
            {

                customer7 = new AppUser();
                customer7.CustomerNumber = 9016;
                customer7.LastName = "Evans";
                customer7.Initial = "";
                customer7.FirstName = "Jim Bob";
                customer7.Birthday = new DateTime(1959, 9, 9);
                customer7.Street = "51 Emmet Parkway";
                customer7.City = "Austin";
                customer7.State = "TX";
                customer7.ZipCode = 78705;
                customer7.SSN = "647-72-4711";
                customer7.UserName = "j.b.evans@aheca.org";
                customer7.Email = "j.b.evans@aheca.org";
                customer7.PhoneNumber = "998-682-5917";
                var result = await _userManager.CreateAsync(customer7, "hampton1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer7 = _db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
            }
            if (await _userManager.IsInRoleAsync(customer7, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer7, "customer");
            }

            _db.SaveChanges();

            AppUser customer8 = _db.Users.FirstOrDefault(u => u.Email == "feeley@penguin.org");
            if (customer8 == null)
            {

                customer8 = new AppUser();
                customer8.CustomerNumber = 9017;
                customer8.LastName = "Feeley";
                customer8.Initial = "K";
                customer8.FirstName = "Lou Ann";
                customer8.Birthday = new DateTime(2001, 1, 12);
                customer8.Street = "65 Darwin Crossing";
                customer8.City = "Austin";
                customer8.State = "TX";
                customer8.ZipCode = 78704;
                customer8.SSN = "577-89-2279";
                customer8.UserName = "feeley@penguin.org";
                customer8.Email = "feeley@penguin.org";
                customer8.PhoneNumber = "346-412-1966";
                var result = await _userManager.CreateAsync(customer8, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer8 = _db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
            }
            if (await _userManager.IsInRoleAsync(customer8, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer8, "customer");
            }

            _db.SaveChanges();

            AppUser customer9 = _db.Users.FirstOrDefault(u => u.Email == "tfreeley@minnetonka.ci.us");
            if (customer9 == null)
            {

                customer9 = new AppUser();
                customer9.CustomerNumber = 9018;
                customer9.LastName = "Freeley";
                customer9.Initial = "P";
                customer9.FirstName = "Tesa";
                customer9.Birthday = new DateTime(1991, 2, 4);
                customer9.Street = "7352 Loftsgordon Court";
                customer9.City = "College Station";
                customer9.State = "TX";
                customer9.ZipCode = 77840;
                customer9.SSN = "853-72-9538";
                customer9.UserName = "tfreeley@minnetonka.ci.us";
                customer9.Email = "tfreeley@minnetonka.ci.us";
                customer9.PhoneNumber = "658-135-7270";
                var result = await _userManager.CreateAsync(customer9, "mustangs");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer9 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
            }
            if (await _userManager.IsInRoleAsync(customer9, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer9, "customer");
            }

            _db.SaveChanges();

            AppUser customer10 = _db.Users.FirstOrDefault(u => u.Email == "mgarcia@gogle.com");
            if (customer10 == null)
            {

                customer10 = new AppUser();
                customer10.CustomerNumber = 9019;
                customer10.LastName = "Garcia";
                customer10.Initial = "L";
                customer10.FirstName = "Margaret";
                customer10.Birthday = new DateTime(1991, 10, 2);
                customer10.Street = " 60 Lunder Point";
                customer10.City = "Austin";
                customer10.State = "TX";
                customer10.ZipCode = 78729;
                customer10.SSN = " 679-75-0653";
                customer10.UserName = "mgarcia@gogle.com";
                customer10.Email = "mgarcia@gogle.com";
                customer10.PhoneNumber = "376-734-7949";
                var result = await _userManager.CreateAsync(customer10, "onetime");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer10 = _db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
            }
            if (await _userManager.IsInRoleAsync(customer10, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer10, "customer");
            }

            _db.SaveChanges();

            AppUser customer11 = _db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");
            if (customer11 == null)
            {

                customer11 = new AppUser();
                customer11.CustomerNumber = 9020;
                customer11.LastName = "Haley";
                customer11.Initial = "E";
                customer11.FirstName = "Charles";
                customer11.Birthday = new DateTime(1974, 7, 10);
                customer11.Street = "8 Warrior Trail";
                customer11.City = "Austin";
                customer11.State = "TX";
                customer11.ZipCode = 78746;
                customer11.SSN = "528-58-6911";
                customer11.UserName = "chaley@thug.com";
                customer11.Email = "chaley@thug.com";
                customer11.PhoneNumber = "219-860-4221";
                var result = await _userManager.CreateAsync(customer11, "pepperoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer11 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
            }
            if (await _userManager.IsInRoleAsync(customer11, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer11, "customer");
            }

            _db.SaveChanges();

            AppUser customer12 = _db.Users.FirstOrDefault(u => u.Email == "jeffh@sonic.com");
            if (customer12 == null)
            {

                customer12 = new AppUser();
                customer12.CustomerNumber = 9021;
                customer12.LastName = "Hampton";
                customer12.Initial = "T.";
                customer12.FirstName = "Jeffrey";
                customer12.Birthday = new DateTime(2004, 3, 10);
                customer12.Street = "9107 Lighthouse Bay Road";
                customer12.City = "Austin";
                customer12.State = "TX";
                customer12.ZipCode = 78756;
                customer12.SSN = "658-45-9102";
                customer12.UserName = "jeffh@sonic.com";
                customer12.Email = "jeffh@sonic.com";
                customer12.PhoneNumber = "122-218-5888";
                var result = await _userManager.CreateAsync(customer12, "raiders");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer12 = _db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
            }
            if (await _userManager.IsInRoleAsync(customer12, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer12, "customer");
            }

            _db.SaveChanges();

            AppUser customer13 = _db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umich.org");
            if (customer13 == null)
            {

                customer13 = new AppUser();
                customer13.CustomerNumber = 9022;
                customer13.LastName = "Hearn";
                customer13.Initial = "B";
                customer13.FirstName = "John";
                customer13.Birthday = new DateTime(1950, 8, 5);
                customer13.Street = "59784 Pierstorff Center";
                customer13.City = "Liberty";
                customer13.State = "TX";
                customer13.ZipCode = 77575;
                customer13.SSN = "712-69-1666";
                customer13.UserName = "wjhearniii@umich.org";
                customer13.Email = "wjhearniii@umich.org";
                customer13.PhoneNumber = "512-307-1976";
                var result = await _userManager.CreateAsync(customer13, "jhearn22");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer13 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
            }
            if (await _userManager.IsInRoleAsync(customer13, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer13, "customer");
            }

            _db.SaveChanges();

            AppUser customer14 = _db.Users.FirstOrDefault(u => u.Email == "ahick@yaho.com");
            if (customer14 == null)
            {

                customer14 = new AppUser();
                customer14.CustomerNumber = 9023;
                customer14.LastName = "Hicks";
                customer14.Initial = "J";
                customer14.FirstName = "Anthony";
                customer14.Birthday = new DateTime(2004, 12, 8);
                customer14.Street = "932 Monica Way";
                customer14.City = "San Antonio";
                customer14.State = "TX";
                customer14.ZipCode = 78203;
                customer14.SSN = "179-94-2233";
                customer14.UserName = "ahick@yaho.com";
                customer14.Email = "ahick@yaho.com";
                customer14.PhoneNumber = "121-194-9601";
                var result = await _userManager.CreateAsync(customer14, "hickhickup");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer14 = _db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
            }
            if (await _userManager.IsInRoleAsync(customer14, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer14, "customer");
            }

            _db.SaveChanges();

            AppUser customer15 = _db.Users.FirstOrDefault(u => u.Email == "ingram@jack.com");
            if (customer15 == null)
            {

                customer15 = new AppUser();
                customer15.CustomerNumber = 9024;
                customer15.LastName = "Ingram";
                customer15.Initial = "S.";
                customer15.FirstName = "Brad";
                customer15.Birthday = new DateTime(2001, 9, 5);
                customer15.Street = "4 Lukken Court";
                customer15.City = "New Braunfels";
                customer15.State = "TX";
                customer15.ZipCode = 78132;
                customer15.SSN = "126-14-4287";
                customer15.UserName = "ingram@jack.com";
                customer15.Email = "ingram@jack.com";
                customer15.PhoneNumber = "137-212-1569";
                var result = await _userManager.CreateAsync(customer15, "ingram2015");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer15 = _db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
            }
            if (await _userManager.IsInRoleAsync(customer15, "customer") == false)
            {
                await _userManager.AddToRoleAsync(customer15, "customer");
            }

            _db.SaveChanges();

            AppUser customer16 = _db.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");

            //if manager hasn't been created, then add them
            if (customer16 == null)
            {
                customer16 = new AppUser();
                customer16.CustomerNumber = 9025;
                customer16.LastName = "Jacobs";
                customer16.FirstName = "Todd";
                customer16.Initial = "L";
                customer16.Birthday = new DateTime(1999, 1, 20);
                customer16.Street = "7 Susan Junction";
                customer16.City = "New York";
                customer16.State = "NY";
                customer16.ZipCode = 10101;
                customer16.SSN = "355-61-0890";
                customer16.Email = "toddj@yourmom.com";
                customer16.UserName = "toddj@yourmom.com";
                customer16.PhoneNumber= "(854) 316-3836";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer16, "toddy25");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer16 = _db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer16, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer16, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer17 = _db.Users.FirstOrDefault(u => u.Email == "thequeen@aska.net");

            //if manager hasn't been created, then add them
            if (customer17 == null)
            {
                customer17 = new AppUser();
                customer17.CustomerNumber = 9026;
                customer17.LastName = "Lawrence";
                customer17.FirstName = "Victoria";
                customer17.Initial = "M.";
                customer17.Birthday = new DateTime(2000, 4, 14);
                customer17.Street = "669 Oak Junction";
                customer17.City = "Lockhart";
                customer17.State = "TX";
                customer17.ZipCode = 78644;
                customer17.SSN = "840-91-4997";
                customer17.Email = "thequeen@aska.net";
                customer17.UserName = "thequeen@aska.net";
                customer17.PhoneNumber= "(321) 416-3359";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer17, "something");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer17 = _db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer17, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer17, "Customer");
            }

            //save changes
            _db.SaveChanges();


            AppUser customer18 = _db.Users.FirstOrDefault(u => u.Email == "linebacker@gogle.com");

            if (customer18 == null)
            {
                customer18 = new AppUser();
                customer18.CustomerNumber = 9027;
                customer18.LastName = "Lineback";
                customer18.FirstName = "Erik";
                customer18.Initial = "W";
                customer18.Birthday = new DateTime(2003, 12, 2);
                customer18.Street = "099 Luster Point";
                customer18.City = "Kingwood";
                customer18.State = "TX";
                customer18.ZipCode = 77325;
                customer18.UserName = "linebacker@gogle.com";
                customer18.Email = "linebacker@gogle.com";
                customer18.PhoneNumber = "(250)526-5350";
                customer18.SSN = "303255592";

                var result = await _userManager.CreateAsync(customer18, "Password1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer18 = _db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
            }

            if (await _userManager.IsInRoleAsync(customer18, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer18, "Customer");
            }

            _db.SaveChanges();

            AppUser customer19 = _db.Users.FirstOrDefault(u => u.Email == "elowe@netscare.net");

            if (customer19 == null)
            {
                customer19 = new AppUser();
                customer19.CustomerNumber = 9028;
                customer19.LastName = "Lowe";
                customer19.FirstName = "Ernest";
                customer19.Initial = "S";
                customer19.Birthday = new DateTime(1977, 12, 7);
                customer19.Street = "35473 Hansons Hill";
                customer19.City = "Beverly Hills";
                customer19.State = "CA";
                customer19.ZipCode = 90210;
                customer19.UserName = "elowe@netscare.net";
                customer19.Email = "elowe@netscare.net";
                customer19.PhoneNumber = "(407)061-9503";
                customer19.SSN = "547721592";

                var result = await _userManager.CreateAsync(customer19, "aclfest2017");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer19 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
            }

            if (await _userManager.IsInRoleAsync(customer19, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer19, "Customer");
            }

            _db.SaveChanges();

            AppUser customer20 = _db.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");

            //if manager hasn't been created, then add them
            if (customer20 == null)
            {
                customer20 = new AppUser();
                customer20.CustomerNumber = 9029;
                customer20.LastName = "Luce";
                customer20.FirstName = "Chuck";
                customer20.Initial = "B";
                customer20.Birthday = new DateTime(1949, 3, 16);
                customer20.Street = "4 Emmet Junction";
                customer20.City = "Navasota";
                customer20.State = "TX";
                customer20.ZipCode = 77868;
                customer20.SSN = "434-46-8800";
                customer20.Email = "cluce@gogle.com";
                customer20.UserName = "cluce@gogle.com";
                customer20.PhoneNumber= "(735) 843-6110";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer20, "nothinggood");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer20 = _db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer20, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer20, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer21 = _db.Users.FirstOrDefault(u => u.Email == "mackcloud@george.com");

            //if manager hasn't been created, then add them
            if (customer21 == null)
            {
                customer21 = new AppUser();
                customer21.CustomerNumber = 9030;
                customer21.LastName = "Macleod";
                customer21.FirstName = "Jennifer";
                customer21.Initial = "D";
                customer21.Birthday = new DateTime(1947, 2, 21);
                customer21.Street = "3 Orin Road";
                customer21.City = "Austin";
                customer21.State = "TX";
                customer21.ZipCode = 78712;
                customer21.SSN = "219-58-3683";
                customer21.Email = "mackcloud@george.com";
                customer21.UserName = "mackcloud@george.com";
                customer21.PhoneNumber= "(724) 017-8229";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer21, "whatever");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer21 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer21, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer21, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer22 = _db.Users.FirstOrDefault(u => u.Email == "cmartin@beets.com");

            //if manager hasn't been created, then add them
            if (customer22 == null)
            {
                customer22 = new AppUser();
                customer22.CustomerNumber = 9031;
                customer22.LastName = "Markham";
                customer22.FirstName = "Elizabeth";
                customer22.Initial = "P.";
                customer22.Birthday = new DateTime(1972, 3, 20);
                customer22.Street = "8171 Commercial Crossing";
                customer22.City = "Austin";
                customer22.State = "TX";
                customer22.ZipCode = 78712;
                customer22.SSN = "116-38-6529";
                customer22.Email = "cmartin@beets.com";
                customer22.UserName = "cmartin@beets.com";
                customer22.PhoneNumber= "(249) 520-0223";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer22, "snowsnow");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer22 = _db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer22, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer22, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer23 = _db.Users.FirstOrDefault(u => u.Email == "clarence@yoho.com");

            //if manager hasn't been created, then add them
            if (customer23 == null)
            {
                customer23 = new AppUser();
                customer23.CustomerNumber = 9032;
                customer23.LastName = "Martin";
                customer23.FirstName = "Clarence";
                customer23.Initial = "A";
                customer23.Birthday = new DateTime(1992, 7, 19);
                customer23.Street = "96 Anthes Place";
                customer23.City = "Schenectady";
                customer23.State = "NY";
                customer23.ZipCode = 12345;
                customer23.SSN = "220-24-4049";
                customer23.Email = "clarence@yoho.com";
                customer23.UserName = "clarence@yoho.com";
                customer23.PhoneNumber= "(408) 617-9161";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer23, "whocares");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer23 = _db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer23, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer23, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer24 = _db.Users.FirstOrDefault(u => u.Email == "gregmartinez@drdre.com");

            //if manager hasn't been created, then add them
            if (customer24 == null)
            {
                customer24 = new AppUser();
                customer24.CustomerNumber = 9033;
                customer24.LastName = "Martinez";
                customer24.FirstName = "Gregory";
                customer24.Initial = "R.";
                customer24.Birthday = new DateTime(1947, 5, 28);
                customer24.Street = "10 Northridge Plaza";
                customer24.City = "Austin";
                customer24.State = "TX";
                customer24.ZipCode = 78717;
                customer24.SSN = "559-67-5740";
                customer24.Email = "gregmartinez@drdre.com";
                customer24.UserName = "gregmartinez@drdre.com";
                customer24.PhoneNumber= "(937) 192-7523";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer24, "xcellent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer24 = _db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer24, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer24, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer25 = _db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");

            //if manager hasn't been created, then add them
            if (customer25 == null)
            {
                customer25 = new AppUser();
                customer25.CustomerNumber = 9034;
                customer25.LastName = "Miller";
                customer25.FirstName = "Charles";
                customer25.Initial = "R";
                customer25.Birthday = new DateTime(1990, 10, 15);
                customer25.Street = "87683 Schmedeman Circle";
                customer25.City = "Austin";
                customer25.State = "TX";
                customer25.ZipCode = 78727;
                customer25.SSN = "209-79-0473";
                customer25.Email = "cmiller@bob.com";
                customer25.UserName = "cmiller@bob.com";
                customer25.PhoneNumber= "(595) 406-3857";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer25, "mydogspot");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer25 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer25, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer25, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer26 = _db.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");

            //if manager hasn't been created, then add them
            if (customer26 == null)
            {
                customer26 = new AppUser();
                customer26.CustomerNumber = 9035;
                customer26.LastName = "Nelson";
                customer26.FirstName = "Kelly";
                customer26.Initial = "T";
                customer26.Birthday = new DateTime(1971, 7, 13);
                customer26.Street = "3244 Ludington Court";
                customer26.City = "Beaumont";
                customer26.State = "TX";
                customer26.ZipCode = 77720;
                customer26.SSN = "227-64-1445";
                customer26.Email = "knelson@aoll.com";
                customer26.UserName = "knelson@aoll.com";
                customer26.PhoneNumber= "(892) 920-9512";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer26, "spotmydog");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer26 = _db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer26, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer26, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer27 = _db.Users.FirstOrDefault(u => u.Email == "joewin@xfactor.com");

            //if manager hasn't been created, then add them
            if (customer27 == null)
            {
                customer27 = new AppUser();
                customer27.CustomerNumber = 9036;
                customer27.LastName = "Nguyen";
                customer27.FirstName = "Joe";
                customer27.Initial = "C";
                customer27.Birthday = new DateTime(1984, 3, 17);
                customer27.Street = "4780 Talisman Court";
                customer27.City = "San Marcos";
                customer27.State = "TX";
                customer27.ZipCode = 78667;
                customer27.SSN = "480-18-2513";
                customer27.Email = "joewin@xfactor.com";
                customer27.UserName = "joewin@xfactor.com";
                customer27.PhoneNumber= "(922) 630-1774";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer27, "joejoejoe");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer27 = _db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer27, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer27, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer28 = _db.Users.FirstOrDefault(u => u.Email == "orielly@foxnews.cnn");

            //if manager hasn't been created, then add them
            if (customer28 == null)
            {
                customer28 = new AppUser();
                customer28.CustomerNumber = 9037;
                customer28.LastName = "O'Reilly";
                customer28.FirstName = "Bill";
                customer28.Initial = "T";
                customer28.Birthday = new DateTime(1959, 7, 8);
                customer28.Street = "4154 Delladonna Plaza";
                customer28.City = "Bergheim";
                customer28.State = "TX";
                customer28.ZipCode = 778004;
                customer28.SSN = "505-04-1746";
                customer28.Email = "orielly@foxnews.cnn";
                customer28.UserName = "orielly@foxnews.cnn";
                customer28.PhoneNumber= "(253) 764-6912";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer28, "billyboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer28 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer28, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer28, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer29 = _db.Users.FirstOrDefault(u => u.Email == "ankaisrad@gogle.com");

            //if manager hasn't been created, then add them
            if (customer29 == null)
            {
                customer29 = new AppUser();
                customer29.CustomerNumber = 9038;
                customer29.LastName = "Radkovich";
                customer29.FirstName = "Anka";
                customer29.Initial = "L";
                customer29.Birthday = new DateTime(1966, 5, 19);
                customer29.Street = "72361 Bayside Drive";
                customer29.City = "Austin";
                customer29.State = "TX";
                customer29.ZipCode = 78789;
                customer29.SSN = "772-85-3188";
                customer29.Email = "ankaisrad@gogle.com";
                customer29.UserName = "ankaisrad@gogle.com";
                customer29.PhoneNumber= "(218) 288-9379";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer29, "radgirl");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer29 = _db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer29, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer29, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer30 = _db.Users.FirstOrDefault(u => u.Email == "megrhodes@freserve.co.uk");

            //if manager hasn't been created, then add them
            if (customer30 == null)
            {
                customer30 = new AppUser();
                customer30.CustomerNumber = 9039;
                customer30.LastName = "Rhodes";
                customer30.FirstName = "Megan";
                customer30.Initial = "C";
                customer30.Birthday = new DateTime(1965, 3, 12);
                customer30.Street = "76875 Hoffman Point";
                customer30.City = "Orlando";
                customer30.State = "FL";
                customer30.ZipCode = 32830;
                customer30.SSN = "855-90-6552";
                customer30.Email = "megrhodes@freserve.co.uk";
                customer30.UserName = "megrhodes@freserve.co.uk";
                customer30.PhoneNumber= "((953) 239-6075";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer30, "meganr34");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer30 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer30, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer30, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer31 = _db.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");

            //if manager hasn't been created, then add them
            if (customer31 == null)
            {
                customer31 = new AppUser();
                customer31.CustomerNumber = 9040;
                customer31.LastName = "Rice";
                customer31.FirstName = "Eryn";
                customer31.Initial = "M";
                customer31.Birthday = new DateTime(1975, 4, 28);
                customer31.Street = "048 Elmside Park";
                customer31.City = "South Padre Island";
                customer31.State = "TX";
                customer31.ZipCode = 78597;
                customer31.SSN = "208-34-2385";
                customer31.Email = "erynrice@aoll.com";
                customer31.UserName = "erynrice@aoll.com";
                customer31.PhoneNumber= "(730) 381-5953";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer31, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer31 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer31, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer31, "Customer");
            }

            //save changes
            _db.SaveChanges();


            AppUser customer32 = _db.Users.FirstOrDefault(u => u.Email == "jorge@noclue.com");

            //if manager hasn't been created, then add them
            if (customer32 == null)
            {
                customer32 = new AppUser();
                customer32.CustomerNumber = 9041;
                customer32.LastName = "Rodriguez";
                customer32.FirstName = "Jorge";

                customer32.Birthday = new DateTime(1953, 12, 8);
                customer32.Street = "01 Browning Pass";
                customer32.City = "Austin";
                customer32.State = "TX";
                customer32.ZipCode = 78744;
                customer32.SSN = "391-71-4611";
                customer32.Email = "jorge@noclue.com";
                customer32.UserName = "jorge@noclue.com";
                customer21.PhoneNumber= "(367) 732-2422";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer32, "alaskaboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer32 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer32, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer32, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer33 = _db.Users.FirstOrDefault(u => u.Email == "mrrogers@lovelyday.com");

            //if manager hasn't been created, then add them
            if (customer33 == null)
            {
                customer33 = new AppUser();
                customer33.CustomerNumber = 9042;
                customer33.LastName = "Rogers";
                customer33.FirstName = "Allen";
                customer33.Initial = "B";
                customer33.Birthday = new DateTime(1973, 4, 22);
                customer33.Street = "844 Anderson Alley";
                customer33.City = "Canyon Lake";
                customer33.State = "TX";
                customer33.ZipCode = 78133;
                customer33.SSN = "308-74-1186";
                customer33.Email = "mrrogers@lovelyday.com";
                customer33.UserName = "mrrogers@lovelyday.com";
                customer33.PhoneNumber= "(391) 170-5385";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer33, "bunnyhop");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer33 = _db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer33, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer33, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer34 = _db.Users.FirstOrDefault(u => u.Email == "stjean@athome.com");

            //if manager hasn't been created, then add them
            if (customer34 == null)
            {
                customer34 = new AppUser();
                customer34.CustomerNumber = 9043;
                customer34.LastName = "Saint-Jean";
                customer34.FirstName = "Olivier";
                customer34.Initial = "M";
                customer34.Birthday = new DateTime(1995, 2, 19);
                customer34.Street = "1891 Docker Point";
                customer34.City = "Austin";
                customer34.State = "TX";
                customer34.ZipCode = 78779;
                customer34.SSN = "832-08-8657";
                customer34.Email = "stjean@athome.com";
                customer34.UserName = "stjean@athome.com";
                customer34.PhoneNumber= "(735) 161-0920";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer34, "dustydusty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer34 = _db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer34, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer34, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer35 = _db.Users.FirstOrDefault(u => u.Email == "saunders@pen.com");

            //if manager hasn't been created, then add them
            if (customer35 == null)
            {
                customer35 = new AppUser();
                customer35.CustomerNumber = 9044;
                customer35.LastName = "Saunders";
                customer35.FirstName = "Sarah";
                customer35.Initial = "J";
                customer35.Birthday = new DateTime(1978, 2, 19);
                customer35.Street = "1469 Upham Road";
                customer35.City = "Austin";
                customer35.State = "TX";
                customer35.ZipCode = 78720;
                customer35.SSN = "485-81-2960";
                customer35.Email = "saunders@pen.com";
                customer35.UserName = "saunders@pen.com";
                customer35.PhoneNumber= "(526) 966-1692";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer35, "jrod2017");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer35 = _db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer35, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer35, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer36 = _db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com");

            //if manager hasn't been created, then add them
            if (customer36 == null)
            {
                customer36 = new AppUser();
                customer36.CustomerNumber = 9045;
                customer36.LastName = "Sewell";
                customer36.FirstName = "William";
                customer36.Initial = "T.";
                customer36.Birthday = new DateTime(2004, 12, 23);
                customer36.Street = "1672 Oak Valley Circle";
                customer36.City = "Austin";
                customer36.State = "TX";
                customer36.ZipCode = 78705;
                customer36.SSN = "845-76-6886";
                customer36.Email = "willsheff@email.com";
                customer36.UserName = "willsheff@email.com";
                customer36.PhoneNumber= "(187) 572-7246";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer36, "martin1234");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer36 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer36, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer36, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer37 = _db.Users.FirstOrDefault(u => u.Email == "sheffiled@gogle.com");

            //if manager hasn't been created, then add them
            if (customer37 == null)
            {
                customer37 = new AppUser();
                customer37.CustomerNumber = 9046;
                customer37.LastName = "Sheffield";
                customer37.FirstName = "Martin";
                customer37.Initial = "J";
                customer37.Birthday = new DateTime(1960, 5, 8);
                customer37.Street = "816 Kennedy Place";
                customer37.City = "Round Rock";
                customer37.State = "TX";
                customer37.ZipCode = 78680;
                customer37.SSN = "786-58-8427";
                customer37.Email = "sheffiled@gogle.com";
                customer37.UserName = "sheffiled@gogle.com";
                customer37.PhoneNumber= "(139) 432-3615";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer37, "penguin12");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer37 = _db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer37, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer37, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer38 = _db.Users.FirstOrDefault(u => u.Email == "johnsmith187@aoll.com");

            //if manager hasn't been created, then add them
            if (customer38 == null)
            {
                customer38 = new AppUser();
                customer38.CustomerNumber = 9047;
                customer38.LastName = "Smith";
                customer38.FirstName = "John";
                customer38.Initial = "A";
                customer38.Birthday = new DateTime(1955, 6, 25);
                customer38.Street = "0745 Golf Road";
                customer38.City = "Austin";
                customer38.State = "TX";
                customer38.ZipCode = 78760;
                customer38.SSN = "833-36-3857";
                customer38.Email = "johnsmith187@aoll.com";
                customer38.UserName = "johnsmith187@aoll.com";
                customer38.PhoneNumber= "(664) 593-7874";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer38, "rogerthat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer38 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer38, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer38, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer39 = _db.Users.FirstOrDefault(u => u.Email == "dustroud@mail.com");

            //if manager hasn't been created, then add them
            if (customer39 == null)
            {
                customer39 = new AppUser();
                customer39.CustomerNumber = 9048;
                customer39.LastName = "Stroud";
                customer39.FirstName = "Dustin";
                customer39.Initial = "P";
                customer39.Birthday = new DateTime(1967, 7, 26);
                customer39.Street = "505 Dexter Plaza";
                customer39.City = "Sweet Home";
                customer39.State = "TX";
                customer39.ZipCode = 77987;
                customer39.SSN = "862-95-5935";
                customer39.Email = "dustroud@mail.com";
                customer39.UserName = "dustroud@mail.com";
                customer39.PhoneNumber= "(647) 025-4680";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer39, "smitty444");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer39 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer39, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer39, "Customer");
            }

            //save changes
            _db.SaveChanges();

            AppUser customer40 = _db.Users.FirstOrDefault(u => u.Email == "estuart@anchor.net");

            //if manager hasn't been created, then add them
            if (customer40 == null)
            {
                customer40 = new AppUser();
                customer40.CustomerNumber = 9049;
                customer40.LastName = "Stuart";
                customer40.FirstName = "Eric";
                customer40.Initial = "D.";
                customer40.Birthday = new DateTime(1947, 12, 4);
                customer40.Street = "585 Claremont Drive";
                customer40.City = "Corpus Christi";
                customer40.State = "TX";
                customer40.ZipCode = 78412;
                customer40.SSN = "401-87-6781";
                customer40.Email = "estuart@anchor.net";
                customer40.UserName = "estuart@anchor.net";
                customer40.PhoneNumber= "(770) 162-1022";



                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(customer40, "stewball");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                customer40 = _db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(customer40, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer40, "Customer");
            }

            //save changes
            _db.SaveChanges();


            AppUser customer50 = _db.Users.FirstOrDefault(u => u.Email == "winner@hootmail.com");

            if (customer50 == null)
            {
                customer50 = new AppUser();
                customer50.CustomerNumber = 9059;
                customer50.LastName = "Winthorpe";
                customer50.FirstName = "Louis";
                customer50.Initial = "L";
                customer50.Birthday = new DateTime(1953, 4, 19);
                customer50.Street = "96850 Summit Crossing";
                customer50.City = "Austin";
                customer50.State = "TX";
                customer50.ZipCode = 78730;
                customer50.UserName = "winner@hootmail.com";
                customer50.Email = "winner@hootmail.com";
                customer50.PhoneNumber = "(373)397-1174";
                customer50.SSN = "445772754";

                var result = await _userManager.CreateAsync(customer50, "louielouie");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer50 = _db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
            }

            if (await _userManager.IsInRoleAsync(customer50, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer50, "Customer");
            }

            _db.SaveChanges();

            AppUser customer51 = _db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");

            if (customer51 == null)
            {
                customer51 = new AppUser();
                customer51.CustomerNumber = 9060;
                customer51.LastName = "Wood";
                customer51.FirstName = "Reagan";
                customer51.Initial = "B.";
                customer51.Birthday = new DateTime(2002, 12, 28);
                customer51.Street = "18354 Bluejay Street";
                customer51.City = "Austin";
                customer51.State = "TX";
                customer51.ZipCode = 78712;
                customer51.UserName = "rwood@voyager.net";
                customer51.Email = "rwood@voyager.net";
                customer51.PhoneNumber = "(843)335-9800";
                customer51.SSN = "805387710";

                var result = await _userManager.CreateAsync(customer51, "woodyman1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer51 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
            }

      
            if (await _userManager.IsInRoleAsync(customer51, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer51, "Customer");
            }

            _db.SaveChanges();

            AppUser employee1 = _db.Users.FirstOrDefault(u => u.Email == "s.barnes@bevosbooks.com");

            if (employee1 == null)
            {
                employee1 = new AppUser();
                employee1.LastName = "Barnes";
                employee1.FirstName = "Susan";
                employee1.Initial = "M";
                employee1.Street = "888 S. Main";
                employee1.City = "Kyle";
                employee1.State = "TX";
                employee1.ZipCode = 78640;
                employee1.SSN = "1112221212";
                employee1.UserName = "s.barnes@bevosbooks.com";
                employee1.Email = "s.barnes@bevosbooks.com";
                employee1.PhoneNumber = "(963)638-9416";


                var result = await _userManager.CreateAsync(employee1, "smitty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee1 = _db.Users.FirstOrDefault(u => u.UserName == "s.barnes@bevosbooks.com");
            }

            if (await _userManager.IsInRoleAsync(employee1, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee1, "Employee");
            }

            _db.SaveChanges();




            AppUser employee2 = _db.Users.FirstOrDefault(u => u.Email == "h.garcia@bevosbooks.com");

            if (employee2 == null)
            {
                employee2 = new AppUser();
                employee2.LastName = "Garcia";
                employee2.FirstName = "Hector";
                employee2.Initial = "W";
                employee2.Street = "777 PBR Drive";
                employee2.City = "Austin";
                employee2.State = "TX";
                employee2.ZipCode = 78712;
                employee2.SSN = "4445554343";
                employee2.UserName = "h.garcia@bevosbooks.com";
                employee2.Email = "h.garcia@bevosbooks.com";
                employee2.PhoneNumber = "(454)713-5738";


                var result = await _userManager.CreateAsync(employee2, "squirrel");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee2 = _db.Users.FirstOrDefault(u => u.UserName == "h.garcia@bevosbooks.com");
            }

            if (await _userManager.IsInRoleAsync(employee2, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee2, "Employee");
            }

            _db.SaveChanges();

            AppUser employee3 = _db.Users.FirstOrDefault(u => u.Email == "b.ingram@bevosbooks.com");

            if (employee3 == null)
            {
                employee3 = new AppUser();
                employee3.LastName = "Ingram";
                employee3.FirstName = "Brad";
                employee3.Initial = "S";
                employee3.Street = "6548 La Posada Ct.";
                employee3.City = "Austin";
                employee3.State = "TX";
                employee3.ZipCode = 78705;
                employee3.SSN = "797348821";
                employee3.UserName = "b.ingram@bevosbooks.com";
                employee3.Email = "b.ingram@bevosbooks.com";
                employee3.PhoneNumber = "(581)734-3315";


                var result = await _userManager.CreateAsync(employee3, "changalang");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee3 = _db.Users.FirstOrDefault(u => u.UserName == "b.ingram@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee3, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee3, "Employee");
            }


            _db.SaveChanges();

            AppUser employee4 = _db.Users.FirstOrDefault(u => u.Email == "j.jackson@bevosbooks.com");

            if (employee4 == null)
            {
                employee4 = new AppUser();
                employee4.LastName = "Jackson";
                employee4.FirstName = "Jack";
                employee4.Initial = "J";
                employee4.Street = "222 Main";
                employee4.City = "Austin";
                employee4.State = "TX";
                employee4.ZipCode = 78760;
                employee4.SSN = "8889993434";
                employee4.UserName = "j.jackson@bevosbooks.com";
                employee4.Email = "j.jackson@bevosbooks.com";
                employee4.PhoneNumber = "(824)191-5317";


                var result = await _userManager.CreateAsync(employee4, "rhythm");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee4 = _db.Users.FirstOrDefault(u => u.UserName == "j.jackson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee4, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee4, "Employee");
            }

            _db.SaveChanges();

            AppUser employee5 = _db.Users.FirstOrDefault(u => u.Email == "t.jacobs@bevosbooks.com");

            if (employee5 == null)
            {
                employee5 = new AppUser();
                employee5.LastName = "Jacobs";
                employee5.FirstName = "Todd";
                employee5.Initial = "L";
                employee5.Street = "4564 Elm St.";
                employee5.City = "Georgetown";
                employee5.State = "TX";
                employee5.ZipCode = 78628;
                employee5.SSN = "341553365";
                employee5.UserName = "t.jacobs@bevosbooks.com";
                employee5.Email = "t.jacobs@bevosbooks.com";
                employee5.PhoneNumber = "(247)782-2475";


                var result = await _userManager.CreateAsync(employee5, "approval");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee5 = _db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee5, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee5, "Employee");
            }

            _db.SaveChanges();



            AppUser employee6 = _db.Users.FirstOrDefault(u => u.Email == "l.jones@bevosbooks.com");

            if (employee6 == null)
            {
                employee6 = new AppUser();
                employee6.LastName = "Jones";
                employee6.FirstName = "Lester";
                employee6.Initial = "L";
                employee6.Street = "999 LeBlat";
                employee6.City = "Austin";
                employee6.State = "TX";
                employee6.ZipCode = 78747;
                employee6.SSN = "9099099999";
                employee6.UserName = "l.jones@bevosbooks.com";
                employee6.Email = "l.jones@bevosbooks.com";
                employee6.PhoneNumber = "(476)496-6462";


                var result = await _userManager.CreateAsync(employee6, "society");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee6 = _db.Users.FirstOrDefault(u => u.UserName == "l.jones@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee6, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee6, "Employee");
            }


            _db.SaveChanges();

            AppUser employee7 = _db.Users.FirstOrDefault(u => u.Email == "b.larson@bevosbooks.com");

            if (employee7 == null)
            {
                employee7 = new AppUser();
                employee7.LastName = "Larson";
                employee7.FirstName = "Bill";
                employee7.Initial = "B";
                employee7.Street = "1212 N. First Ave";
                employee7.City = "Round Rock";
                employee7.State = "TX";
                employee7.ZipCode = 78665;
                employee7.SSN = "5554443333";
                employee7.UserName = "b.larson@bevosbooks.com";
                employee7.Email = "b.larson@bevosbooks.com";
                employee7.PhoneNumber = "(335)525-8855";


                var result = await _userManager.CreateAsync(employee7, "tanman");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee7 = _db.Users.FirstOrDefault(u => u.UserName == "b.larson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee7, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee7, "Employee");
            }

            _db.SaveChanges();


            AppUser employee8 = _db.Users.FirstOrDefault(u => u.Email == "v.lawrence@bevosbooks.com");

            if (employee8 == null)
            {
                employee8 = new AppUser();
                employee8.LastName = "Lawrence";
                employee8.FirstName = "Victoria";
                employee8.Initial = "Y";
                employee8.Street = "6639 Bookworm Ln.";
                employee8.City = "Austin";
                employee8.State = "TX";
                employee8.ZipCode = 78712;
                employee8.SSN = "770097399";
                employee8.UserName = "v.lawrence@bevosbooks.com";
                employee8.Email = "v.lawrence@bevosbooks.com";
                employee8.PhoneNumber = "(751)127-3054";


                var result = await _userManager.CreateAsync(employee8, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee8 = _db.Users.FirstOrDefault(u => u.UserName == "v.lawrence@bevosbooks.com");
            }

            if (await _userManager.IsInRoleAsync(employee8, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee8, "Employee");
            }

            _db.SaveChanges();

            AppUser employee9 = _db.Users.FirstOrDefault(u => u.Email == "m.lopez@bevosbooks.com");

            if (employee9 == null)
            {
                employee9 = new AppUser();
                employee9.LastName = "Lopez";
                employee9.FirstName = "Marshall";
                employee9.Initial = "T";
                employee9.Street = "90 SW North St";
                employee9.City = "Austin";
                employee9.State = "TX";
                employee9.ZipCode = 78729;
                employee9.SSN = "2223332222";
                employee9.UserName = "m.lopez@bevosbooks.com";
                employee9.Email = "m.lopez@bevosbooks.com";
                employee9.PhoneNumber = "(747)790-7070";


                var result = await _userManager.CreateAsync(employee9, "swansong");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee9 = _db.Users.FirstOrDefault(u => u.UserName == "m.lopez@bevosbooks.com");
            }

            if (await _userManager.IsInRoleAsync(employee9, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee9, "Employee");
            }


            _db.SaveChanges();


            AppUser employee10 = _db.Users.FirstOrDefault(u => u.Email == "j.macleod@bevosbooks.com");

            if (employee10 == null)
            {
                employee10 = new AppUser();
                employee10.LastName = "MacLeod";
                employee10.FirstName = "Jennifer";
                employee10.Initial = "D";
                employee10.Street = "2504 Far West Blvd.";
                employee10.City = "Austin";
                employee10.State = "TX";
                employee10.ZipCode = 78705;
                employee10.SSN = "775908138";
                employee10.UserName = "j.macleod@bevosbooks.com";
                employee10.Email = "j.macleod@bevosbooks.com";
                employee10.PhoneNumber = "(262)121-6845";


                var result = await _userManager.CreateAsync(employee10, "fungus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee10 = _db.Users.FirstOrDefault(u => u.UserName == "j.macleod@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee10, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee10, "Employee");
            }


            _db.SaveChanges();


            AppUser employee11 = _db.Users.FirstOrDefault(u => u.Email == "e.markham@bevosbooks.com");

            if (employee11 == null)
            {
                employee11 = new AppUser();
                employee11.LastName = "Markham";
                employee11.FirstName = "Elizabeth";
                employee11.Initial = "K";
                employee11.Street = "7861 Chevy Chase";
                employee11.City = "Austin";
                employee11.State = "TX";
                employee11.ZipCode = 78785;
                employee11.SSN = "101529845";
                employee11.UserName = "e.markham@bevosbooks.com";
                employee11.Email = "e.markham@bevosbooks.com";
                employee11.PhoneNumber = "(502)807-5807";


                var result = await _userManager.CreateAsync(employee11, "median");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee11 = _db.Users.FirstOrDefault(u => u.UserName == "e.markham@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee11, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee11, "Employee");
            }

            _db.SaveChanges();


            AppUser employee12 = _db.Users.FirstOrDefault(u => u.Email == "g.martinez@bevosbooks.com");

            if (employee12 == null)
            {
                employee12 = new AppUser();
                employee12.LastName = "Martinez";
                employee12.FirstName = "Gregory";
                employee12.Initial = "R";
                employee12.Street = "8295 Sunset Blvd.";
                employee12.City = "Austin";
                employee12.State = "TX";
                employee12.ZipCode = 78712;
                employee12.SSN = "463566718";
                employee12.UserName = "g.martinez@bevosbooks.com";
                employee12.Email = "g.martinez@bevosbooks.com";
                employee12.PhoneNumber = "(199)470-8542";


                var result = await _userManager.CreateAsync(employee12, "decorate");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee12 = _db.Users.FirstOrDefault(u => u.UserName == "g.martinez@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee12, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee12, "Employee");
            }

            _db.SaveChanges();


            AppUser employee13 = _db.Users.FirstOrDefault(u => u.Email == "j.mason@bevosbooks.com");

            if (employee13 == null)
            {
                employee13 = new AppUser();
                employee13.LastName = "Mason";
                employee13.FirstName = "Jack";
                employee13.Initial = "L";
                employee13.Street = "444 45th St";
                employee13.City = "Austin";
                employee13.State = "TX";
                employee13.ZipCode = 78701;
                employee13.SSN = "1112223232";
                employee13.UserName = "j.mason@bevosbooks.com";
                employee13.Email = "j.mason@bevosbooks.com";
                employee13.PhoneNumber = "(174)813-6441";


                var result = await _userManager.CreateAsync(employee13, "rankmary");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee13 = _db.Users.FirstOrDefault(u => u.UserName == "j.mason@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee13, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee13, "Employee");
            }

            _db.SaveChanges();


            AppUser employee14 = _db.Users.FirstOrDefault(u => u.Email == "c.miller@bevosbooks.com");

            if (employee14 == null)
            {
                employee14 = new AppUser();
                employee14.LastName = "Miller";
                employee14.FirstName = "Charles";
                employee14.Initial = "R";
                employee14.Street = "8962 Main St.";
                employee14.City = "Austin";
                employee14.State = "TX";
                employee14.ZipCode = 78709;
                employee14.SSN = "353308615";
                employee14.UserName = "c.miller@bevosbooks.com";
                employee14.Email = "c.miller@bevosbooks.com";
                employee14.PhoneNumber = "(899)931-9585";


                var result = await _userManager.CreateAsync(employee14, "kindly");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee14 = _db.Users.FirstOrDefault(u => u.UserName == "c.miller@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee14, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee14, "Employee");
            }


            _db.SaveChanges();


            AppUser employee15 = _db.Users.FirstOrDefault(u => u.Email == "m.nguyen@bevosbooks.com");

            if (employee15 == null)
            {
                employee15 = new AppUser();
                employee15.LastName = "Nguyen";
                employee15.FirstName = "Mary";
                employee15.Initial = "J";
                employee15.Street = "465 N. Bear Cub";
                employee15.City = "Austin";
                employee15.State = "TX";
                employee15.ZipCode = 78734;
                employee15.SSN = "7776665555";
                employee15.UserName = "m.nguyen@bevosbooks.com";
                employee15.Email = "m.nguyen@bevosbooks.com";
                employee15.PhoneNumber = "(871)674-6381";


                var result = await _userManager.CreateAsync(employee15, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee15 = _db.Users.FirstOrDefault(u => u.UserName == "m.nguyen@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee15, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee15, "Employee");
            }

            _db.SaveChanges();


            AppUser employee16 = _db.Users.FirstOrDefault(u => u.Email == "s.rankin@bevosbooks.com");

            if (employee16 == null)
            {
                employee16 = new AppUser();
                employee16.LastName = "Rankin";
                employee16.FirstName = "Suzie";
                employee16.Initial = "R";
                employee16.Street = "23 Dewey Road";
                employee16.City = "Austin";
                employee16.State = "TX";
                employee16.ZipCode = 78712;
                employee16.SSN = "1911919111";
                employee16.UserName = "s.rankin@bevosbooks.com";
                employee16.Email = "s.rankin@bevosbooks.com";
                employee16.PhoneNumber = "(523)902-9525";


                var result = await _userManager.CreateAsync(employee16, "walkamile");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee16 = _db.Users.FirstOrDefault(u => u.UserName == "s.rankin@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee16, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee16, "Employee");
            }

            _db.SaveChanges();

            AppUser employee17 = _db.Users.FirstOrDefault(u => u.Email == "m.rhodes@bevosbooks.com");

            if (employee17 == null)
            {
                employee17 = new AppUser();
                employee17.LastName = "Rhodes";
                employee17.FirstName = "Megan";
                employee17.Initial = "C";
                employee17.Street = "4587 Enfield Rd.";
                employee17.City = "Austin";
                employee17.State = "TX";
                employee17.ZipCode = 78729;
                employee17.SSN = "353904746";
                employee17.UserName = "m.rhodes@bevosbooks.com";
                employee17.Email = "m.rhodes@bevosbooks.com";
                employee17.PhoneNumber = "(123)213-9514";


                var result = await _userManager.CreateAsync(employee17, "ingram45");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee17 = _db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee17, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee17, "Employee");
            }


            _db.SaveChanges();


            AppUser employee18 = _db.Users.FirstOrDefault(u => u.Email == "s.saunders@bevosbooks.com");

            if (employee18 == null)
            {
                employee18 = new AppUser();
                employee18.LastName = "Saunders";
                employee18.FirstName = "Sarah";
                employee18.Initial = "M";
                employee18.Street = "332 Avenue C";
                employee18.City = "Austin";
                employee18.State = "TX";
                employee18.ZipCode = 78733;
                employee18.SSN = "500987810";
                employee18.UserName = "s.saunders@bevosbooks.com";
                employee18.Email = "s.saunders@bevosbooks.com";
                employee18.PhoneNumber = "(903)634-9587";


                var result = await _userManager.CreateAsync(employee18, "nostalgic");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee18 = _db.Users.FirstOrDefault(u => u.UserName == "s.saunders@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee18, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee18, "Employee");
            }

            _db.SaveChanges();


            AppUser employee19 = _db.Users.FirstOrDefault(u => u.Email == "m.sheffield@bevosbooks.com");

            if (employee19 == null)
            {
                employee19 = new AppUser();
                employee19.LastName = "Sheffield";
                employee19.FirstName = "Martin";
                employee19.Initial = "J";
                employee19.Street = "3886 Avenue A";
                employee19.City = "San Marcos";
                employee19.State = "TX";
                employee19.ZipCode = 78666;
                employee19.SSN = "223449167";
                employee19.UserName = "m.sheffield@bevosbooks.com";
                employee19.Email = "m.sheffield@bevosbooks.com";
                employee19.PhoneNumber = "(934)919-2978";


                var result = await _userManager.CreateAsync(employee19, "evanescent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee19 = _db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee19, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee19, "Employee");
            }


            _db.SaveChanges();

            AppUser employee20 = _db.Users.FirstOrDefault(u => u.Email == "c.silva@bevosbooks.com");

            if (employee20 == null)
            {
                employee20 = new AppUser();
                employee20.LastName = "Silva";
                employee20.FirstName = "Cindy";
                employee20.Initial = "S";
                employee20.Street = "900 4th St";
                employee20.City = "Austin";
                employee20.State = "TX";
                employee20.ZipCode = 78758;
                employee20.SSN = "7776661111";
                employee20.UserName = "c.silva@bevosbooks.com";
                employee20.Email = "c.silva@bevosbooks.com";
                employee20.PhoneNumber = "(487)432-8170";


                var result = await _userManager.CreateAsync(employee20, "stewboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee20 = _db.Users.FirstOrDefault(u => u.UserName == "c.silva@bevosbooks.com");
            }

            if (await _userManager.IsInRoleAsync(employee20, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee20, "Employee");
            }

            _db.SaveChanges();



            AppUser employee21 = _db.Users.FirstOrDefault(u => u.Email == "e.stuart@bevosbooks.com");

            if (employee21 == null)
            {
                employee21 = new AppUser();
                employee21.LastName = "Stuart";
                employee21.FirstName = "Eric";
                employee21.Initial = "F";
                employee21.Street = "5576 Toro Ring";
                employee21.City = "Austin";
                employee21.State = "TX";
                employee21.ZipCode = 78758;
                employee21.SSN = "363998335";
                employee21.UserName = "e.stuart@bevosbooks.com";
                employee21.Email = "e.stuart@bevosbooks.com";
                employee21.PhoneNumber = "(196)784-6827";


                var result = await _userManager.CreateAsync(employee21, "instrument");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee21 = _db.Users.FirstOrDefault(u => u.UserName == "e.stuart@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee21, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee21, "Employee");
            }

            _db.SaveChanges();


            AppUser employee22 = _db.Users.FirstOrDefault(u => u.Email == "j.tanner@bevosbooks.com");

            if (employee22 == null)
            {
                employee22 = new AppUser();
                employee22.LastName = "Tanner";
                employee22.FirstName = "Jeremy";
                employee22.Initial = "S";
                employee22.Street = "4347 Almstead";
                employee22.City = "Austin";
                employee22.State = "TX";
                employee22.ZipCode = 78712;
                employee22.SSN = "904440929";
                employee22.UserName = "j.tanner@bevosbooks.com";
                employee22.Email = "j.tanner@bevosbooks.com";
                employee22.PhoneNumber = "(592)302-6779";


                var result = await _userManager.CreateAsync(employee22, "hecktour");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee22 = _db.Users.FirstOrDefault(u => u.UserName == "j.tanner@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee22, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee22, "Employee");
            }

            _db.SaveChanges();



            AppUser employee23 = _db.Users.FirstOrDefault(u => u.Email == "a.taylor@bevosbooks.com");

            if (employee23 == null)
            {
                employee23 = new AppUser();
                employee23.LastName = "Taylor";
                employee23.FirstName = "Allison";
                employee23.Initial = "R";
                employee23.Street = "467 Nueces St.";
                employee23.City = "Austin";
                employee23.State = "TX";
                employee23.ZipCode = 78727;
                employee23.SSN = "934778452";
                employee23.UserName = "a.taylor@bevosbooks.com";
                employee23.Email = "a.taylor@bevosbooks.com";
                employee23.PhoneNumber = "(724)619-5827";


                var result = await _userManager.CreateAsync(employee23, "countryrhodes");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                employee23 = _db.Users.FirstOrDefault(u => u.UserName == "a.taylor@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(employee23, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(employee23, "Employee");
            }

            _db.SaveChanges();

            AppUser customer41 = _db.Users.FirstOrDefault(u => u.Email == "peterstump@noclue.com");

            if (customer41 == null)
            {
                customer41 = new AppUser();
                customer41.CustomerNumber = 9050;
                customer41.LastName = "Stump";
                customer41.FirstName = "Peter";
                customer41.Initial = "L";
                customer41.Birthday = new DateTime(1974, 7, 10);
                customer41.Street = "89035 Welch Circle";
                customer41.City = "Pflugerville";
                customer41.State = "TX";
                customer41.ZipCode = 78660;
                customer41.UserName = "peterstump@noclue.com";
                customer41.Email = "peterstump@noclue.com";
                customer41.PhoneNumber = "(218)196-0061";
                customer41.SSN = "414559948";

                var result = await _userManager.CreateAsync(customer41, "slowwind");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer41 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
            }

            if (await _userManager.IsInRoleAsync(customer41, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer41, "Customer");
            }

            _db.SaveChanges();




            AppUser customer42 = _db.Users.FirstOrDefault(u => u.Email == "jtanner@mustang.net");

            if (customer42 == null)
            {
                customer42 = new AppUser();
                customer42.CustomerNumber = 9051;
                customer42.LastName = "Tanner";
                customer42.FirstName = "Jeremy";
                customer42.Initial = "S.";
                customer42.Birthday = new DateTime(1944, 1, 11);
                customer42.Street = "4 Stang Trail";
                customer42.City = "Austin";
                customer42.State = "TX";
                customer42.ZipCode = 78702;
                customer42.UserName = "jtanner@mustang.net";
                customer42.Email = "jtanner@mustang.net";
                customer42.PhoneNumber = "(990)846-9499";
                customer42.SSN = "215599614";

                var result = await _userManager.CreateAsync(customer42, "tanner5454");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer42 = _db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
            }

            if (await _userManager.IsInRoleAsync(customer42, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer42, "Customer");
            }

            AppUser customer43 = _db.Users.FirstOrDefault(u => u.Email == "taylordjay@aoll.com");

            if (customer43 == null)
            {
                customer43 = new AppUser();
                customer43.CustomerNumber = 9052;
                customer43.LastName = "Taylor";
                customer43.FirstName = "Allison";
                customer43.Initial = "R.";
                customer43.Birthday = new DateTime(1990, 11, 14);
                customer43.Street = "726 Twin Pines Avenue";
                customer43.City = "Austin";
                customer43.State = "TX";
                customer43.ZipCode = 78713;
                customer43.UserName = "taylordjay@aoll.com";
                customer43.Email = "taylordjay@aoll.com";
                customer43.PhoneNumber = "(701)191-8647";
                customer43.SSN = "263917172";

                var result = await _userManager.CreateAsync(customer43, "allyrally");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer43 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
            }

            if (await _userManager.IsInRoleAsync(customer43, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer43, "Customer");
            }

            _db.SaveChanges();
            AppUser customer44 = _db.Users.FirstOrDefault(u => u.Email == "rtaylor@gogle.com");

            if (customer44 == null)
            {
                customer44 = new AppUser();
                customer44.CustomerNumber = 9053;
                customer44.LastName = "Taylor";
                customer44.FirstName = "Rachel";
                customer44.Initial = "K.";
                customer44.Birthday = new DateTime(1976, 1, 18);
                customer44.Street = "06605 Sugar Drive";
                customer44.City = "Austin";
                customer44.State = "TX";
                customer44.ZipCode = 78712;
                customer44.UserName = "rtaylor@gogle.com";
                customer44.Email = "rtaylor@gogle.com";
                customer44.PhoneNumber = "(893)791-0053";
                customer44.SSN = "774061511";

                var result = await _userManager.CreateAsync(customer44, "taylorbaylor");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer44 = _db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
            }
           

            if (await _userManager.IsInRoleAsync(customer44, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer44, "Customer");
            }

            _db.SaveChanges();

            AppUser customer45 = _db.Users.FirstOrDefault(u => u.Email == "teefrank@noclue.com");

            if (customer45 == null)
            {
                customer45 = new AppUser();
                customer45.CustomerNumber = 9054;
                customer45.LastName = "Tee";
                customer45.FirstName = "Frank";
                customer45.Initial = "J";
                customer45.Birthday = new DateTime(1998, 9, 6);
                customer45.Street = "3567 Dawn Plaza";
                customer45.City = "Austin";
                customer45.State = "TX";
                customer45.ZipCode = 78786;
                customer45.UserName = "teefrank@noclue.com";
                customer45.Email = "teefrank@noclue.com";
                customer45.PhoneNumber = "(639)456-8913";
                customer45.SSN = "522653064";

                var result = await _userManager.CreateAsync(customer45, "teeoff22");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer45 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
            }

            if (await _userManager.IsInRoleAsync(customer45, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer45, "Customer");
            }
            _db.SaveChanges();

            AppUser customer46 = _db.Users.FirstOrDefault(u => u.Email == "ctucker@alphabet.co.uk");

            if (customer46 == null)
            {
                customer46 = new AppUser();
                customer46.CustomerNumber = 9055;
                customer46.LastName = "Tucker";
                customer46.FirstName = "Clent";
                customer46.Initial = "J";
                customer46.Birthday = new DateTime(1943, 2, 25);
                customer46.Street = "704 Northland Alley";
                customer46.City = "San Antonio";
                customer46.State = "TX";
                customer46.ZipCode = 78279;
                customer46.UserName = "ctucker@alphabet.co.uk";
                customer46.Email = "ctucker@alphabet.co.uk";
                customer46.PhoneNumber = "(267)683-8676";
                customer46.SSN = "876294912";

                var result = await _userManager.CreateAsync(customer46, "tucksack1");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer46 = _db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
            }

            if (await _userManager.IsInRoleAsync(customer46, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer46, "Customer");
            }

            _db.SaveChanges();

            AppUser customer47 = _db.Users.FirstOrDefault(u => u.Email == "avelasco@yoho.com");

            if (customer47 == null)
            {
                customer47 = new AppUser();
                customer47.CustomerNumber = 9056;
                customer47.LastName = "Velasco";
                customer47.FirstName = "Allen";
                customer47.Initial = "G";
                customer47.Birthday = new DateTime(1985, 9, 10);
                customer47.Street = "772 Harbort Point";
                customer47.City = "Navasota";
                customer47.State = "TX";
                customer47.ZipCode = 77868;
                customer47.UserName = "avelasco@yoho.com";
                customer47.Email = "avelasco@yoho.com";
                customer47.PhoneNumber = "(345)290-9754";
                customer47.SSN = "216679243";

                var result = await _userManager.CreateAsync(customer47, "meow88");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer47 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
            }


            if (await _userManager.IsInRoleAsync(customer47, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer47, "Customer");
            }

            _db.SaveChanges();

            AppUser customer48 = _db.Users.FirstOrDefault(u => u.Email == "vinovino@grapes.com");

            if (customer48 == null)
            {
                customer48 = new AppUser();
                customer48.CustomerNumber = 9057;
                customer48.LastName = "Vino";
                customer48.FirstName = "Janet";
                customer48.Initial = "E";
                customer48.Birthday = new DateTime(1985, 2, 7);
                customer48.Street = "1 Oak Valley Place";
                customer48.City = "Boston";
                customer48.State = "MA";
                customer48.ZipCode = 02114;
                customer48.UserName = "vinovino@grapes.com";
                customer48.Email = "vinovino@grapes.com";
                customer48.PhoneNumber = "(856)708-9194";
                customer48.SSN = "565574107";

                var result = await _userManager.CreateAsync(customer48, "vinovino");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer48 = _db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
            }


            if (await _userManager.IsInRoleAsync(customer48, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer48, "Customer");
            }

            _db.SaveChanges();

            AppUser customer49 = _db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");

            if (customer49 == null)
            {
                customer49 = new AppUser();
                customer49.CustomerNumber = 9058;
                customer49.LastName = "West";
                customer49.FirstName = "Jake";
                customer49.Initial = "T";
                customer49.Birthday = new DateTime(1976, 1, 9);
                customer49.Street = "48743 Banding Parkway";
                customer49.City = "Marble Falls";
                customer49.State = "TX";
                customer49.ZipCode = 78654;
                customer49.UserName = "westj@pioneer.net";
                customer49.Email = "westj@pioneer.net";
                customer49.PhoneNumber = "(626)078-4394";
                customer49.SSN = "390376155";

                var result = await _userManager.CreateAsync(customer49, "gowest");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                customer49 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
            }

            if (await _userManager.IsInRoleAsync(customer49, "Customer") == false)
            {
                await _userManager.AddToRoleAsync(customer49, "Customer");
            }

            _db.SaveChanges();


            //check to see if the manager has been added
            //AppUser manager1 = _db.Users.FirstOrDefault(u => u.Email == "c.baker@bevosbooks.com");

            //if manager hasn't been created, then add them
            //if (manager1 == null)
            /*{
                manager1 = new AppUser();
                manager1.LastName = "Baker";
                manager1.FirstName = "Christopher";
                manager1.Initial = "E";
                manager1.Street = "1245 Lake Libris Dr.";
                manager1.City = "Cedar Park";
                manager1.State = "TX";
                manager1.ZipCode = 78613;
                manager1.SSN = "401661146";
                manager1.UserName = "c.baker@bevosbooks.com";
                manager1.Email = "c.baker@bevosbooks.com";
                manager1.PhoneNumber = "(339)532-5649";

                var result = await _userManager.CreateAsync(manager1, "dewey4");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager1 = _db.Users.FirstOrDefault(u => u.UserName == "c.baker@bevosbooks.com");
            }

       

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager1, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager1, "Manager");
            }

            _db.SaveChanges();
            */

            AppUser manager2 = _db.Users.FirstOrDefault(u => u.Email == "e.rice@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager2 == null)
            {
                manager2 = new AppUser();
                manager2.LastName = "Rice";
                manager2.FirstName = "Eryb";
                manager2.Initial = "M";
                manager2.Street = "1245 Lake Libris Dr.";
                manager2.City = "Austin";
                manager2.State = "TX";
                manager2.ZipCode = 78746;
                manager2.SSN = "454776657";
                manager2.UserName = "e.rice@bevosbooks.com";
                manager2.Email = "e.rice@bevosbooks.com";
                manager2.PhoneNumber = "(270)660-2803";


                var result = await _userManager.CreateAsync(manager2, "arched");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                manager2 = _db.Users.FirstOrDefault(u => u.UserName == "e.rice@bevosbooks.com");
            }

    
            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager2, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager2, "Manager");
            }

            _db.SaveChanges();

            AppUser manager3 = _db.Users.FirstOrDefault(u => u.Email == "a.rogers@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager3 == null)
            {
                manager3 = new AppUser();
                manager3.LastName = "Rogers";
                manager3.FirstName = "Allen";
                manager3.Initial = "H";
                manager3.Street = "4965 Oak Hill";
                manager3.City = "Austin";
                manager3.State = "TX";
                manager3.ZipCode = 78705;
                manager3.SSN = "700002943";
                manager3.UserName = "a.rogers@bevosbooks.com";
                manager3.Email = "a.rogers@bevosbooks.com";
                manager3.PhoneNumber = "(413)964-5586";


                var result = await _userManager.CreateAsync(manager3, "lottery");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                manager3 = _db.Users.FirstOrDefault(u => u.UserName == "a.rogers@bevosbooks.com");
            }

            _db.SaveChanges();
            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager3, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager3, "Manager");
            }

            AppUser manager4 = _db.Users.FirstOrDefault(u => u.Email == "w.sewell@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager4 == null)
            {
                manager4 = new AppUser();
                manager4.LastName = "Sewell";
                manager4.FirstName = "William";
                manager4.Initial = "G";
                manager4.Street = "2365 51st St.";
                manager4.City = "Austin";
                manager4.State = "TX";
                manager4.ZipCode = 78755;
                manager4.SSN = "500830084";
                manager4.UserName = "w.sewell@bevosbooks.com";
                manager4.Email = "w.sewell@bevosbooks.com";
                manager4.PhoneNumber = "(722)430-8314";


                var result = await _userManager.CreateAsync(manager4, "offbeat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                manager4 = _db.Users.FirstOrDefault(u => u.UserName == "w.sewell@bevosbooks.com");
            }


            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager4, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager4, "Manager");
            }

            _db.SaveChanges();

            AppUser manager5 = _db.Users.FirstOrDefault(u => u.Email == "r.taylor@bevosbooks.com");

            //if manager hasn't been created, then add them
            if (manager5 == null)
            {
                manager5 = new AppUser();
                manager5.LastName = "Taylor";
                manager5.FirstName = "Rachel";
                manager5.Initial = "O";
                manager5.Street = "345 Longview Dr.";
                manager5.City = "Austin";
                manager5.State = "TX";
                manager5.ZipCode = 78746;
                manager5.SSN = "393412631";
                manager5.UserName = "r.taylor@bevosbooks.com";
                manager5.Email = "r.taylor@bevosbooks.com";
                manager5.PhoneNumber = "(907)123-6087";


                var result = await _userManager.CreateAsync(manager5, "landus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                manager5 = _db.Users.FirstOrDefault(u => u.UserName == "r.taylor@bevosbooks.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager5, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager5, "Manager");
            }

            _db.SaveChanges();
            

        }

    }
}

