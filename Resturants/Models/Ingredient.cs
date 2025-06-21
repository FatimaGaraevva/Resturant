namespace Resturants.Models
{
    public class Ingredient:BaseEntity
    {
        public string Name { get; set; }

        // Bir ingrediyent bir neçə menyuda ola bilər
        public List<Menu> Menus { get; set; } 
    }
}
