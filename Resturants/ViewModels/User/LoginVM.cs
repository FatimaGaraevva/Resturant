using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.User
{
    public class LoginVM
    {

        [MaxLength(256)]
        public string UserNameOrEmail { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
