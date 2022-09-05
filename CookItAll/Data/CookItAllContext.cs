using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookItAll.Models;

namespace CookItAll.Data
{
    public class CookItAllContext : DbContext
    {
        public CookItAllContext (DbContextOptions<CookItAllContext> options)
            : base(options)
        {
        }

        public DbSet<CookItAll.Models.Category> Category { get; set; } = default!;

        public DbSet<CookItAll.Models.Fridge>? Fridge { get; set; }

        public DbSet<CookItAll.Models.Ingredient>? Ingredient { get; set; }

        public DbSet<CookItAll.Models.IngredientAmount>? IngredientAmount { get; set; }

        public DbSet<CookItAll.Models.Recipe>? Recipe { get; set; }

        public DbSet<CookItAll.Models.Step>? Step { get; set; }
    }
}
