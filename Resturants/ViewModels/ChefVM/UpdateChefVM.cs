using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.ChefVM
{
    public class UpdateChefVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ExistingImage { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
    }

}
