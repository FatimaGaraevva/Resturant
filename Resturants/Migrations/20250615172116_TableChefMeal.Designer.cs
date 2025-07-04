﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturants.DAL;

#nullable disable

namespace Resturants.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250615172116_TableChefMeal")]
    partial class TableChefMeal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Resturants.Models.Chef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("Resturants.Models.ChefMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChefId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("MealId");

                    b.ToTable("ChefMeal");
                });

            modelBuilder.Entity("Resturants.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChefId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChefId")
                        .IsUnique()
                        .HasFilter("[ChefId] IS NOT NULL");

                    b.HasIndex("MealId")
                        .IsUnique()
                        .HasFilter("[MealId] IS NOT NULL");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Resturants.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Resturants.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Resturants.Models.SosialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChefId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.ToTable("SosialMedia");
                });

            modelBuilder.Entity("Resturants.Models.ChefMeal", b =>
                {
                    b.HasOne("Resturants.Models.Chef", "Chef")
                        .WithMany("ChefMeals")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturants.Models.Meal", "Meal")
                        .WithMany("ChefMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Resturants.Models.Image", b =>
                {
                    b.HasOne("Resturants.Models.Chef", "Chef")
                        .WithOne("Image")
                        .HasForeignKey("Resturants.Models.Image", "ChefId");

                    b.HasOne("Resturants.Models.Meal", "Meal")
                        .WithOne("Image")
                        .HasForeignKey("Resturants.Models.Image", "MealId");

                    b.Navigation("Chef");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Resturants.Models.Rating", b =>
                {
                    b.HasOne("Resturants.Models.Meal", "Menu")
                        .WithMany("Ratings")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Resturants.Models.SosialMedia", b =>
                {
                    b.HasOne("Resturants.Models.Chef", "Chef")
                        .WithMany("SosialMedias")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");
                });

            modelBuilder.Entity("Resturants.Models.Chef", b =>
                {
                    b.Navigation("ChefMeals");

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("SosialMedias");
                });

            modelBuilder.Entity("Resturants.Models.Meal", b =>
                {
                    b.Navigation("ChefMeals");

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
