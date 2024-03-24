﻿// <auto-generated />
using System;
using CaloriesCouter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaloriesCouter.Migrations
{
    [DbContext(typeof(CaloriesCouterContext))]
    [Migration("20240324170238_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaloriesCouter.Models.DailyMeals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DailyMeals");
                });

            modelBuilder.Entity("CaloriesCouter.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarbsAmmoutPer100g")
                        .HasColumnType("int");

                    b.Property<int>("DailyMealsID")
                        .HasColumnType("int");

                    b.Property<int>("FatAmmoutPer100g")
                        .HasColumnType("int");

                    b.Property<int>("KcalAmmoutPer100g")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProteinAmmoutPer100g")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DailyMealsID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CaloriesCouter.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("KcalIntake")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CaloriesCouter.Models.DailyMeals", b =>
                {
                    b.HasOne("CaloriesCouter.Models.User", "User")
                        .WithMany("Meals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CaloriesCouter.Models.Product", b =>
                {
                    b.HasOne("CaloriesCouter.Models.DailyMeals", "Meal")
                        .WithMany("Products")
                        .HasForeignKey("DailyMealsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("CaloriesCouter.Models.DailyMeals", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CaloriesCouter.Models.User", b =>
                {
                    b.Navigation("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}