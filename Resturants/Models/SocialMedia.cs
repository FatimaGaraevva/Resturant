namespace Resturants.Models
{
    public class SocialMedia:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        //reletion
        public int ChefId { get; set; }
        public Chef Chef { get; set; }

    }
}
