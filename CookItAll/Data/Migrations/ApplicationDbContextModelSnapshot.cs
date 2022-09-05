﻿// <auto-generated />
using System;
using CookItAll.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookItAll.Data.Migrations
{
    [DbContext(typeof(CookItAllContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CookItAll.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CookItAll.Models.Fridge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fridge");
                });

            modelBuilder.Entity("CookItAll.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("FridgeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FridgeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("CookItAll.Models.IngredientAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("IngredientAmount");
                });

            modelBuilder.Entity("CookItAll.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Recipe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Recipe");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("CookItAll.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Step");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("CookItAll.Models.Ingredient", b =>
                {
                    b.HasOne("CookItAll.Models.Category", "Category")
                        .WithMany("Ingredients")
                        .HasForeignKey("CategoryId");

                    b.HasOne("CookItAll.Models.Fridge", "Fridge")
                        .WithMany("Ingredients")
                        .HasForeignKey("FridgeId");

                    b.Navigation("Category");

                    b.Navigation("Fridge");
                });

            modelBuilder.Entity("CookItAll.Models.IngredientAmount", b =>
                {
                    b.HasOne("CookItAll.Models.Ingredient", "Ingredient")
                        .WithMany("IngredientAmounts")
                        .HasForeignKey("IngredientId");

                    b.HasOne("CookItAll.Models.Recipe", "Recipe")
                        .WithMany("IngredientAmounts")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CookItAll.Models.Recipe", b =>
                {
                    b.HasOne("CookItAll.Models.Step", "Step")
                        .WithMany()
                        .HasForeignKey("Recipe");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("CookItAll.Models.Step", b =>
                {
                    b.HasOne("CookItAll.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("Step");

                    b.HasOne("CookItAll.Models.Step", "NextStep")
                        .WithMany()
                        .HasForeignKey("Step");

                    b.Navigation("NextStep");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CookItAll.Models.Category", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("CookItAll.Models.Fridge", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("CookItAll.Models.Ingredient", b =>
                {
                    b.Navigation("IngredientAmounts");
                });

            modelBuilder.Entity("CookItAll.Models.Recipe", b =>
                {
                    b.Navigation("IngredientAmounts");
                });
#pragma warning restore 612, 618
        }
    }
}
