using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.ChefVM
{
    public class CreateChefVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please upload a photo.")]
        [DataType(DataType.Upload)]
        public IFormFile? Photo { get; set; }
    }

}
