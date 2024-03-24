namespace CaloriesCouter.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int DailyMealsID { get; set; }
        public string? Name { get; set; }
        public int KcalAmmoutPer100g { get; set; }
        public int ProteinAmmoutPer100g { get; set; }
        public int FatAmmoutPer100g { get; set; }
        public int CarbsAmmoutPer100g { get; set; }

        public virtual DailyMeals Meal {  get; set; }
    }
}
