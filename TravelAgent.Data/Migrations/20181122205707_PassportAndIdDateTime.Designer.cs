﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgent.Data;

namespace TravelAgent.Data.Migrations
{
    [DbContext(typeof(TravelAgentDbContext))]
    [Migration("20181122205707_PassportAndIdDateTime")]
    partial class PassportAndIdDateTime
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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

            modelBuilder.Entity("TravelAgent.Data.Models.AdditionalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int?>("HolidayId");

                    b.Property<decimal>("Price");

                    b.Property<string>("ReservationId");

                    b.Property<int>("TourId");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("TourId");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayDescription");

                    b.Property<byte[]>("DayPicture");

                    b.Property<string>("DayTitle");

                    b.Property<int?>("HolidayId");

                    b.Property<int>("TourId");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.HasIndex("TourId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Destination");

                    b.Property<int>("DestinationType");

                    b.Property<byte[]>("HeaderImage");

                    b.Property<int>("Nights");

                    b.Property<string>("PriceDoesNotIncludes");

                    b.Property<string>("PriceIncludes");

                    b.Property<string>("StartingPoint");

                    b.Property<string>("Title");

                    b.Property<string>("UsefulInformation");

                    b.HasKey("Id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HolidayId");

                    b.Property<string>("HotelDescription");

                    b.Property<string>("HotelLink");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.HotelPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelPicture");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsFinalized");

                    b.Property<string>("Password");

                    b.Property<DateTime>("ReservationTime");

                    b.Property<int>("SeatId");

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("TouristId");

                    b.Property<int>("TourstId");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.HasIndex("TouristId");

                    b.HasIndex("TripId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId");

                    b.Property<bool>("IsReserved");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Subscriber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Destination");

                    b.Property<int>("DestinationType");

                    b.Property<byte[]>("HeaderImage");

                    b.Property<int>("Nights");

                    b.Property<string>("PriceDoesNotIncludes");

                    b.Property<string>("PriceIncludes");

                    b.Property<string>("StartingPoint");

                    b.Property<string>("Title");

                    b.Property<string>("UsefulInformation");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("HolidayId");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TourId");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.HasIndex("TourId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Adress");

                    b.Property<string>("EGN");

                    b.Property<string>("FirstNameCyrilic");

                    b.Property<string>("FirstNameLatin");

                    b.Property<string>("IdCard");

                    b.Property<DateTime>("IdCardDateOfIssue");

                    b.Property<DateTime>("IdCardValidityDate");

                    b.Property<string>("LastNameCyrilic");

                    b.Property<string>("LastNameLatin");

                    b.Property<DateTime>("PasportDateOfIssue");

                    b.Property<string>("PasportNumber");

                    b.Property<DateTime>("PasportValidityDate");

                    b.Property<string>("SurNameCyrilic");

                    b.Property<string>("SurNameLatin");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.AdditionalService", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Holiday")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("HolidayId");

                    b.HasOne("TravelAgent.Data.Models.Reservation")
                        .WithMany("IncludedAdditionalServices")
                        .HasForeignKey("ReservationId");

                    b.HasOne("TravelAgent.Data.Models.Tour", "Tour")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Bus", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Trip", "Trip")
                        .WithMany("Buses")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Day", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Holiday")
                        .WithMany("TourDays")
                        .HasForeignKey("HolidayId");

                    b.HasOne("TravelAgent.Data.Models.Tour", "Tour")
                        .WithMany("TourDays")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Hotel", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Holiday")
                        .WithMany("Hotels")
                        .HasForeignKey("HolidayId");
                });

            modelBuilder.Entity("TravelAgent.Data.Models.HotelPicture", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Hotel", "Hotel")
                        .WithMany("HotelPictures")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Reservation", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelAgent.Data.Models.User", "Tourist")
                        .WithMany("Reservations")
                        .HasForeignKey("TouristId");

                    b.HasOne("TravelAgent.Data.Models.Trip", "Trip")
                        .WithMany("Reservations")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Seat", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Bus", "Bus")
                        .WithMany("Seats")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Models.Trip", b =>
                {
                    b.HasOne("TravelAgent.Data.Models.Holiday")
                        .WithMany("Trips")
                        .HasForeignKey("HolidayId");

                    b.HasOne("TravelAgent.Data.Models.Tour", "Tour")
                        .WithMany("Trips")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
