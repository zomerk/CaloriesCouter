using Microsoft.EntityFrameworkCore;
using CaloriesCouter.Models;
namespace CaloriesCouter.Data
{
    public class CaloriesCouterContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CaloriesCouterContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("CaloriesCouterContext"));
        }


        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<DailyMeals> Meals { get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;


    }
}
