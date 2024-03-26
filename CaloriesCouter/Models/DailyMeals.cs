namespace CaloriesCouter.Models
{
    public class DailyMeals
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Type { get; set; }

        public DateTime Date { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
