namespace Resturants.Models
{
    public class Chef:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string Specialization { get; set; }
        public string Description { get; set; }
      

    }
}
