using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaloriesCouter.Models;

namespace CaloriesCouter.Data
{
    public class CaloriesCouterContext : DbContext
    {
        public CaloriesCouterContext (DbContextOptions<CaloriesCouterContext> options)
            : base(options)
        {
        }

        public DbSet<CaloriesCouter.Models.Product> Product { get; set; } = default!;
        public DbSet<CaloriesCouter.Models.DailyMeals> Meals { get; set; } = default!;

        public DbSet<CaloriesCouter.Models.User> Users { get; set; } = default!;


    }
}
