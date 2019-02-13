﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Team12FinalProject.DAL;

namespace Team12FinalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181206215149_InitialCreate1000")]
    partial class InitialCreate1000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Team12FinalProject.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CustomerNumber");

                    b.Property<bool>("Disabled");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Initial");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SSN");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("ZipCode");

                    b.Property<int>("myApprovedReviews");

                    b.Property<int>("myRejectedReviews");

                    b.Property<int>("myReviews");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("CopiesOnHand");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<bool>("Discontinued");

                    b.Property<int?>("GenreID");

                    b.Property<int>("InitialCopies");

                    b.Property<decimal>("InitialCost");

                    b.Property<DateTime?>("LastOrdered");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<int>("QuantityOnOrder");

                    b.Property<int>("Reorder");

                    b.Property<string>("Title");

                    b.Property<int>("UniqueID");

                    b.HasKey("BookID");

                    b.HasIndex("GenreID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Coupon", b =>
                {
                    b.Property<int>("CouponID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("CouponType");

                    b.Property<bool>("Enabled");

                    b.HasKey("CouponID");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Team12FinalProject.Models.CreditCard", b =>
                {
                    b.Property<int>("CreditCardID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<string>("CardHolder")
                        .IsRequired();

                    b.Property<int>("CardType");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("CreditCardID");

                    b.HasIndex("AppUserId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreType");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<bool>("CheckOutStatus");

                    b.Property<int?>("CouponID");

                    b.Property<int?>("CreditCardID");

                    b.Property<decimal>("DiscountAmt");

                    b.Property<string>("Note");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.Property<decimal>("ShippingAmt");

                    b.HasKey("OrderID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CouponID");

                    b.HasIndex("CreditCardID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Team12FinalProject.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<decimal>("BookPrice");

                    b.Property<int?>("OrderID");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("BookID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Procurement", b =>
                {
                    b.Property<int>("ProcurementID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<bool>("Completed");

                    b.Property<DateTime>("ProcurementDate");

                    b.Property<int>("ProcurementType");

                    b.HasKey("ProcurementID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Procurements");
                });

            modelBuilder.Entity("Team12FinalProject.Models.ProcurementDetail", b =>
                {
                    b.Property<int>("ProcurementDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<decimal>("BookPrice");

                    b.Property<decimal>("ExtendedPrice");

                    b.Property<int?>("ProcurementID");

                    b.Property<int>("Quantity");

                    b.HasKey("ProcurementDetailID");

                    b.HasIndex("BookID");

                    b.HasIndex("ProcurementID");

                    b.ToTable("ProcurementDetails");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<int>("Approve");

                    b.Property<DateTime>("ApproveDate");

                    b.Property<string>("ApproverId");

                    b.Property<string>("AuthorId");

                    b.Property<int?>("BookID");

                    b.Property<int>("CustomerRating");

                    b.Property<string>("Reviews")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ReviewID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ShippingAddition");

                    b.Property<decimal>("ShippingBase");

                    b.HasKey("ShippingID");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Team12FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Team12FinalProject.Models.Book", b =>
                {
                    b.HasOne("Team12FinalProject.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreID");
                });

            modelBuilder.Entity("Team12FinalProject.Models.CreditCard", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser", "AppUser")
                        .WithMany("CreditCards")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Order", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Team12FinalProject.Models.Coupon", "Coupon")
                        .WithMany("Orders")
                        .HasForeignKey("CouponID");

                    b.HasOne("Team12FinalProject.Models.CreditCard", "CreditCard")
                        .WithMany("Orders")
                        .HasForeignKey("CreditCardID");
                });

            modelBuilder.Entity("Team12FinalProject.Models.OrderDetail", b =>
                {
                    b.HasOne("Team12FinalProject.Models.Book", "Book")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BookID");

                    b.HasOne("Team12FinalProject.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Procurement", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser", "AppUser")
                        .WithMany("Procurements")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Team12FinalProject.Models.ProcurementDetail", b =>
                {
                    b.HasOne("Team12FinalProject.Models.Book", "Book")
                        .WithMany("ProcurementDetails")
                        .HasForeignKey("BookID");

                    b.HasOne("Team12FinalProject.Models.Procurement", "Procurement")
                        .WithMany("ProcurementDetails")
                        .HasForeignKey("ProcurementID");
                });

            modelBuilder.Entity("Team12FinalProject.Models.Review", b =>
                {
                    b.HasOne("Team12FinalProject.Models.AppUser", "AppUser")
                        .WithMany("Reviews")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Team12FinalProject.Models.AppUser", "Approver")
                        .WithMany("ReviewApproved")
                        .HasForeignKey("ApproverId");

                    b.HasOne("Team12FinalProject.Models.AppUser", "Author")
                        .WithMany("ReviewWritten")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Team12FinalProject.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookID");
                });
#pragma warning restore 612, 618
        }
    }
}
