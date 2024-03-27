namespace CaloriesCouter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int KcalIntake { get; set; }

        public virtual ICollection<DailyMeals>? Meals { get; set; }

    }
}
