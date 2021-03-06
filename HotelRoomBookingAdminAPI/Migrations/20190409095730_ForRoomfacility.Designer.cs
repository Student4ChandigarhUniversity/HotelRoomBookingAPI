﻿// <auto-generated />
using System;
using HotelRoomBookingAdminAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelRoomBookingAdminAPI.Migrations
{
    [DbContext(typeof(DataDBContext))]
    [Migration("20190409095730_ForRoomfacility")]
    partial class ForRoomfacility
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<int?>("CustomerId");

                    b.Property<double>("TotalAmount");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContactNumber");

                    b.Property<string>("CustomerAddress");

                    b.Property<DateTime>("CustomerDateOfBirth");

                    b.Property<string>("CustomerEmailId");

                    b.Property<string>("CustomerFirstName");

                    b.Property<string>("CustomerGender");

                    b.Property<string>("CustomerLastName");

                    b.Property<string>("CustomerPassword");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelAddress");

                    b.Property<string>("HotelCity");

                    b.Property<long>("HotelContactNumber");

                    b.Property<string>("HotelCountry");

                    b.Property<string>("HotelDescription");

                    b.Property<string>("HotelDistrict");

                    b.Property<string>("HotelEmailId");

                    b.Property<string>("HotelImage");

                    b.Property<string>("HotelName")
                        .HasColumnName("HotelName")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int>("HotelRating");

                    b.Property<string>("HotelState");

                    b.Property<int>("HotelTypeId");

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<string>("RoomDescription");

                    b.Property<string>("RoomImage");

                    b.Property<int>("RoomPrice");

                    b.Property<string>("RoomType")
                        .HasColumnName("RoomType")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.HotelType", b =>
                {
                    b.Property<int>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelTypeDescription");

                    b.Property<string>("HotelTypeName")
                        .HasColumnName("HotelTypeName")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int?>("UserDetailUserId");

                    b.HasKey("HotelTypeId");

                    b.HasIndex("UserDetailUserId");

                    b.ToTable("HotelTypes");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId");

                    b.Property<double>("PaymentAmount");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PaymentDescription");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.RoomFacility", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool>("Ekettle");

                    b.Property<bool>("IsAvilable");

                    b.Property<bool>("Refrigerator");

                    b.Property<string>("RoomFacilityDescription")
                        .HasColumnName("RoomFacilityDescription")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("RoomId");

                    b.Property<bool>("Wifi");

                    b.HasKey("RoomFacilityId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.UserDetail", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserContactNumber");

                    b.Property<string>("UserEmailId");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.Property<string>("UserType");

                    b.HasKey("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Booking", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Hotel", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.HotelType", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.HotelRoom", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.HotelType", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.UserDetail", "UserDetail")
                        .WithMany("HotelTypes")
                        .HasForeignKey("UserDetailUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.Payment", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.Booking", "Booking")
                        .WithOne("Payment")
                        .HasForeignKey("HotelRoomBookingAdminAPI.Models.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelRoomBookingAdminAPI.Models.RoomFacility", b =>
                {
                    b.HasOne("HotelRoomBookingAdminAPI.Models.HotelRoom", "HotelRoom")
                        .WithOne("RoomFacility")
                        .HasForeignKey("HotelRoomBookingAdminAPI.Models.RoomFacility", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
