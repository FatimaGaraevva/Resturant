using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.User
{
    public class RegisterVM
    {
        [MinLength(3)]
        public string Name { get; set; }
        [MinLength(5)]
        public string Surname { get; set; }
        [MaxLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(256)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(8)]
        public string CurrentPassword { get; set; }
    }
}
