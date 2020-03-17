﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCar.Data;

namespace RentCar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentCar.Models.Car", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("back_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("baggage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("front_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("left_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priceperday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("production_year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("right_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("top_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transmision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentCar.Models.Transaction", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("cars_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("driver")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nama_pemesan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("returned_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("transaction_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("used_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("User_id");

                    b.HasIndex("transaction_id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("RentCar.Models.Transaction_Details", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_actions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fraud_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gross_amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("merchant_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("order_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("signature_key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status_message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transaction_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transaction_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transaction_time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Transaction_Details");
                });

            modelBuilder.Entity("RentCar.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentCar.Models.Transaction", b =>
                {
                    b.HasOne("RentCar.Models.User", "User")
                        .WithMany("transactions")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentCar.Models.Transaction_Details", "Transaction_Details")
                        .WithMany()
                        .HasForeignKey("transaction_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
