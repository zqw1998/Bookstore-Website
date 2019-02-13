using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team12FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Team12FinalProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //You need one db set for each model class. For example:
        public DbSet<Book> Books { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Procurement> Procurements { get; set; }

        public DbSet<ProcurementDetail> ProcurementDetails { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Shipping> Shippings {get;set;}
    }
}
