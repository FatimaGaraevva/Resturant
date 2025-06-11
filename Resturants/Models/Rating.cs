namespace Resturants.Models
{
    public class Rating:BaseEntity
    {
        public int Stars { get; set;}
        //reletion
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
