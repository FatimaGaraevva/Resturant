using System.ComponentModel.DataAnnotations;

namespace Resturants.Models
{
    public class Reservation:BaseEntity
    {
       

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
    }
}
