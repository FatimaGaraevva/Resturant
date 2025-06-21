namespace Resturants.ViewModels.ChefVM
{
    public class ChefListItemVM
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public string Image { get; set; }

        public string Specialization { get; set; }

        public string Description { get; set; }

        // Əgər sosial media məlumatları göstərmək istəyirsənsə:
        public List<string>? SocialMediaLinks { get; set; }
    }
}

