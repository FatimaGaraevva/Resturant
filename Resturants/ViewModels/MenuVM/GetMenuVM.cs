namespace Resturants.ViewModels.Meal
{
    public class GetMenuVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double? AverageRating { get; set; }
        public bool IsAvailable { get; set; }
        public string ChefFullName { get; set; }
    }
}
